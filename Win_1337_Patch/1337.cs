using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Security.AccessControl;
using System.Security.Principal;

namespace Win_1337_Patch
{
    public partial class Form1 : Form
    {
        private string exe = String.Empty;
        private string f1337 = String.Empty;

        [System.Runtime.InteropServices.DllImport("Imagehlp.dll")]
        private static extern bool ImageRemoveCertificate(IntPtr handle, int index);

        public Form1()
        {
            InitializeComponent();
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            string ver = "v" + version.Major + "." + version.Minor;
            this.Text = "Win 1337 Apply Patch File " + ver;
            linkdfox.Text = ver + " By DeltaFoX";
        }
        private void set()
        {
            t1337.Text = Ellipsis.Compact(f1337, t1337, EllipsisFormat.Path);
            toolTip1.SetToolTip(t1337, f1337);
            Properties.Settings.Default["url1337"] = f1337;
            Properties.Settings.Default.Save();
            string[] lines = File.ReadAllLines(f1337);
            if (!check_Symbol(lines[0]))
                return;
            string unf = lines[0].Substring(1).ToLower().Trim();
            string nf = Path.GetFileName(unf);
            string ext = Path.GetExtension(unf);
            OpenFileDialog apriDialogoFile1 = new OpenFileDialog();
            apriDialogoFile1.FileName = nf;
            apriDialogoFile1.Filter = "File " + ext + "|" + nf;
            apriDialogoFile1.FilterIndex = 0;
            apriDialogoFile1.Title = "Select the file \"" + nf + "\" File...";

            if (apriDialogoFile1.ShowDialog() == DialogResult.OK)
            {
                exe = apriDialogoFile1.FileName;
                texe.Text = Ellipsis.Compact(Path.GetFileName(exe), texe, EllipsisFormat.Path);
                toolTip1.SetToolTip(texe, exe);
                Properties.Settings.Default["urlexe"] = exe;
                Properties.Settings.Default.Save();
            }
            else
            {
                t1337.Text = "Select a .1337 File...";
                texe.Text = "Select the Exe/Dll to Patch...";
                f1337 = String.Empty;
                exe = String.Empty;
            }
        }
        private void t1337_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                f1337 = ((string[])e.Data.GetData(DataFormats.FileDrop, false))[0];
                set();
            }
            catch
            {
                //Nothing;
            }
            return;
        }
        private void btnSelect1337_Click(object sender, EventArgs e)
        {
            try
            {
                string url1337 = Properties.Settings.Default["url1337"].ToString();
                OpenFileDialog apriDialogoFile1 = new OpenFileDialog();
                apriDialogoFile1.Filter = "File 1337|*.*";
                apriDialogoFile1.FilterIndex = 0;
                apriDialogoFile1.Title = "Select the .1337 File...";
                apriDialogoFile1.InitialDirectory = url1337 != "" ? url1337 : Directory.GetCurrentDirectory() + "\\";
                apriDialogoFile1.RestoreDirectory = true;
                if (apriDialogoFile1.ShowDialog() == DialogResult.OK)
                {
                    f1337 = apriDialogoFile1.FileName;
                    set();
                }
            }
            catch
            {
                //Nothing;
            }
            return;
        }

        private void t1337_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private bool check_Symbol(string s)
        {
            if (!s.StartsWith(">"))
            {
                MessageBox.Show("The .1337 File is not valid...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void Patch_Click(object sender, EventArgs e)
        {
            if (f1337 == String.Empty)
            {
                MessageBox.Show("Select a .1337 File...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                DFoX_Patch();
            }
            catch
            {
                MessageBox.Show("Problem occured when Patching...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void DFoX_Patch()
        {
            if (!File.Exists(exe) || !File.Exists(f1337))
            {
                MessageBox.Show("Files are no Longer Present...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string[] lines = File.ReadAllLines(f1337);
            if (!check_Symbol(lines[0]))
                return;
            if (lines[0].Substring(1).ToLower().Trim() != Path.GetFileName(exe).ToLower().Trim())
            {
                MessageBox.Show("The .1337 File is not valid for selected exe/dll...\n\n(\"" + lines[0].Substring(1).ToLower() + "\" but you have selected \"" + Path.GetFileName(exe).ToLower() + "\")", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            byte[] bexe = File.ReadAllBytes(exe);
            bool ok = true;
            for (var i = 1; i < lines.Length; i += 1)
            {
                if (lines[i].Trim() != "")
                {
                    string[] tmp = lines[i].Split(':');
                    int offsetHex = int.Parse(tmp[0], System.Globalization.NumberStyles.HexNumber) - (cfileoffsett.Checked ? 0xC00 : 0);
                    string[] tmp2 = tmp[1].Replace("->", ":").Split(':');
                    byte e = bexe[offsetHex];
                    byte f = byte.Parse(tmp2[0], System.Globalization.NumberStyles.HexNumber);
                    if (bexe[offsetHex] == byte.Parse(tmp2[0], System.Globalization.NumberStyles.HexNumber))
                        bexe[offsetHex] = byte.Parse(tmp2[1], System.Globalization.NumberStyles.HexNumber);
                    else
                    {
                        MessageBox.Show("Offset [" + offsetHex.ToString("X") + "] Wrong...\n\nSet 0x" + bexe[offsetHex].ToString("X") + " -> I expected 0x" + byte.Parse(tmp2[0], System.Globalization.NumberStyles.HexNumber).ToString("X"), "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ok = false;
                        break;
                    }
                }
            }
            if (ok)
            {
                if (controlloBackup.Checked == true)
                {
                    if (File.Exists(exe + ".BAK"))
                        File.Delete(exe + ".BAK");
                    File.Copy(exe, exe + ".BAK");
                }
                if (File.Exists(exe))
                    File.Delete(exe);
                File.WriteAllBytes(exe, bexe);
                SistemaPeCks(exe);
                MessageBox.Show("File " + Path.GetFileName(exe) + " Patched...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return;
        }
        private void SistemaPeCks(string file)
        {
            try
            {
                using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.ReadWrite))
                {
                    ImageRemoveCertificate(fs.SafeFileHandle.DangerousGetHandle(), 0);
                    fs.Close();
                }
                mCheckSum PE = new mCheckSum();
                PE.FixCheckSum(file);
            }
            catch
            {
                //Nothing
            }
            return;
        }
        private void DFoX_Load(object sender, EventArgs e)
        {
            string urlexe = Properties.Settings.Default["urlexe"].ToString().Trim();
            string url1337 = Properties.Settings.Default["url1337"].ToString().Trim();
            cfileoffsett.Checked = (bool)Properties.Settings.Default["fixoffset"];
            controlloBackup.Checked = (bool)Properties.Settings.Default["backup"];
            if (urlexe != "")
            {
                texe.Text = Ellipsis.Compact(Path.GetFileName(urlexe), texe, EllipsisFormat.Path);
                toolTip1.SetToolTip(texe, urlexe);
                exe = urlexe;
            }
            else
                texe.Text = "Select the Exe/Dll to Patch...";
            if (url1337 != "" && urlexe != "")
            {
                t1337.Text = Ellipsis.Compact(url1337, t1337, EllipsisFormat.Path);
                toolTip1.SetToolTip(t1337, url1337);
                f1337 = url1337;
            }
            else
                t1337.Text = "Select a .1337 File...";
        }

        private void cfileoffsett_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["fixoffset"] = cfileoffsett.Checked;
            Properties.Settings.Default.Save();
        }

        private void controlloBackup_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default["backup"] = controlloBackup.Checked;
            Properties.Settings.Default.Save();
        }

        private void linkdfox_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            _apriUrl(@"https://github.com/Deltafox79/Win_1337_Apply_Patch");
        }
        private void _apriUrl(string url)
        {
            try
            {
                string browserPath = ottieniLaPathBrowser();
                if (browserPath == string.Empty)
                    browserPath = "iexplore";
                Process process = new Process();
                process.StartInfo = new ProcessStartInfo(browserPath);
                process.StartInfo.Arguments = url;
                process.Start();
            }
            catch
            {
                //Nothing
            }
        }
        private static string ottieniLaPathBrowser()
        {
            string name = String.Empty;
            RegistryKey regKey = null;
            try
            {
                var regDefault = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\FileExts\\.htm\\UserChoice", false);
                var stringDefault = regDefault.GetValue("ProgId");

                regKey = Registry.ClassesRoot.OpenSubKey(stringDefault + "\\shell\\open\\command", false);
                name = regKey.GetValue(null).ToString().ToLower().Replace("" + (char)34, "");

                if (!name.EndsWith("exe"))
                    name = name.Substring(0, name.LastIndexOf(".exe") + 4);

            }
            catch
            {
                return String.Empty;
            }
            finally
            {
                if (regKey != null)
                    regKey.Close();
            }
            return name;
        }

        private void t1337_DoubleClick(object sender, EventArgs e)
        {
            btnSelect1337.PerformClick();
        }

        private void cchangeOwnership_CheckedChanged(object sender, EventArgs e)
        {
            if (cchangeOwnership.Checked)
            {
                try
                {
                    if (!string.IsNullOrEmpty(exe))
                    {
                        UnlockDLL(exe);
                        MessageBox.Show($"Ownership of {exe} changed to Administrators and full control granted.", "Ownership Changed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Please select a DLL/EXE file first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cchangeOwnership.Checked = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cchangeOwnership.Checked = false;
                }
            }
        }

        private void UnlockDLL(string filePath)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("The specified file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                FileSecurity fileSecurity = File.GetAccessControl(filePath);
                IdentityReference administrators = new NTAccount("Administrators");

                fileSecurity.SetOwner(administrators);

                File.SetAccessControl(filePath, fileSecurity);

                FileSystemAccessRule accessRule = new FileSystemAccessRule(administrators,
                    FileSystemRights.FullControl,
                    AccessControlType.Allow);

                fileSecurity.AddAccessRule(accessRule);

                File.SetAccessControl(filePath, fileSecurity);

                MessageBox.Show($"Owner changed to 'Administrators' and full control permissions granted to 'Administrators' for file: {filePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while changing ownership: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
