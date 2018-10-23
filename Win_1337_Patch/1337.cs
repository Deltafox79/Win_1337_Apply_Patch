using System;
using System.IO;
using System.Windows.Forms;

namespace Win_1337_Patch
{
    public partial class Form1 : Form
    {
        public string exe = String.Empty;
        public string f1337 = String.Empty;

        [System.Runtime.InteropServices.DllImport("Imagehlp.dll")]
        private static extern bool ImageRemoveCertificate(IntPtr handle, int index);

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectExe_Click(object sender, EventArgs e)
        {
            string urlexe = Properties.Settings.Default["urlexe"].ToString();
            OpenFileDialog apriDialogoFile1 = new OpenFileDialog();
            apriDialogoFile1.Filter = "File Exe|*.exe|File Dll|*.dll|All File|*.*";
            apriDialogoFile1.FilterIndex = 0;
            apriDialogoFile1.Title = "Select the file Exe/Dll File...";
            apriDialogoFile1.InitialDirectory = urlexe != "" ? urlexe : Directory.GetCurrentDirectory() + "\\";
            apriDialogoFile1.RestoreDirectory = true;
            if (apriDialogoFile1.ShowDialog() == DialogResult.OK)
            {
                exe = apriDialogoFile1.FileName;
                texe.Text = Ellipsis.Compact(exe, texe, EllipsisFormat.Path);
                toolTip1.SetToolTip(texe, exe);
                Properties.Settings.Default["urlexe"] = exe;
                Properties.Settings.Default.Save();
            }
        }

        private void btnSelect1337_Click(object sender, EventArgs e)
        {
            string url1337 = Properties.Settings.Default["url1337"].ToString();
            OpenFileDialog apriDialogoFile1 = new OpenFileDialog();
            apriDialogoFile1.Filter = "File 1337|*.*";
            apriDialogoFile1.FilterIndex = 0;
            apriDialogoFile1.Title = "Select the file 1337 File...";
            apriDialogoFile1.InitialDirectory = url1337 != "" ? url1337 : Directory.GetCurrentDirectory() + "\\";
            apriDialogoFile1.RestoreDirectory = true;
            if (apriDialogoFile1.ShowDialog() == DialogResult.OK)
            {
                f1337 = apriDialogoFile1.FileName;
                t1337.Text = Ellipsis.Compact(f1337, t1337, EllipsisFormat.Path);
                toolTip1.SetToolTip(t1337, f1337);
                Properties.Settings.Default["url1337"] = f1337;
                Properties.Settings.Default.Save();
            }
        }
        private void texe_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void texe_DragDrop(object sender, DragEventArgs e)
        {
            exe = ((string[])e.Data.GetData(DataFormats.FileDrop, false))[0];
            texe.Text = Ellipsis.Compact(exe, texe, EllipsisFormat.Path);
            toolTip1.SetToolTip(texe, exe);
            Properties.Settings.Default["urlexe"] = exe;
            Properties.Settings.Default.Save();

        }

        private void t1337_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void t1337_DragDrop(object sender, DragEventArgs e)
        {
            f1337 = ((string[])e.Data.GetData(DataFormats.FileDrop, false))[0];
            t1337.Text = Ellipsis.Compact(f1337, t1337, EllipsisFormat.Path);
            toolTip1.SetToolTip(t1337, f1337);
            Properties.Settings.Default["url1337"] = f1337;
            Properties.Settings.Default.Save();
        }
        private void Esci_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Patch_Click(object sender, EventArgs e)
        {
            if (exe == String.Empty || f1337 == String.Empty)
            {
                MessageBox.Show("Select a " + ((exe == String.Empty) ? "Exe" : "1337") + " File...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                DFoX_Patch();
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Sorry !!!\nYou Run the Program as Administrator...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("Problems on Patch...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (lines[0].Substring(0,1) != ">")
            {
                MessageBox.Show("File 1337 is not valid...", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (lines[0].Substring(1).ToLower() != Path.GetFileName(exe).ToLower())
            {
                MessageBox.Show("File 1337 is not valid for selected exe...\n\n(\"" + lines[0].Substring(1).ToLower() + "\" vs \"" + Path.GetFileName(exe).ToLower() + "\")", "Info...", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (urlexe != "")
            {
                texe.Text = Ellipsis.Compact(urlexe, texe, EllipsisFormat.Path);
                toolTip1.SetToolTip(texe, urlexe);
                exe = urlexe;
            }
            else
                texe.Text = "Select Exe to Patch...";
            if (url1337 != "")
            {
                t1337.Text = Ellipsis.Compact(url1337, t1337, EllipsisFormat.Path);
                toolTip1.SetToolTip(t1337, url1337);
                f1337 = url1337;
            }
            else
                t1337.Text = "Select .1337 File...";
        }
    }
}
