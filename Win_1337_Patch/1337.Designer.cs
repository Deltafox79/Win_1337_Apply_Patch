namespace Win_1337_Patch
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label7 = new System.Windows.Forms.Label();
            this.t1337 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.texe = new System.Windows.Forms.TextBox();
            this.btnSelect1337 = new System.Windows.Forms.Button();
            this.linkdfox = new System.Windows.Forms.LinkLabel();
            this.Patch = new System.Windows.Forms.Button();
            this.controlloBackup = new System.Windows.Forms.CheckBox();
            this.cfileoffsett = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cchangeOwnership = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DarkGreen;
            this.label7.Location = new System.Drawing.Point(7, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "1337 File :";
            // 
            // t1337
            // 
            this.t1337.AllowDrop = true;
            this.t1337.BackColor = System.Drawing.SystemColors.Info;
            this.t1337.ForeColor = System.Drawing.Color.DarkRed;
            this.t1337.Location = new System.Drawing.Point(90, 5);
            this.t1337.Name = "t1337";
            this.t1337.ReadOnly = true;
            this.t1337.Size = new System.Drawing.Size(343, 20);
            this.t1337.TabIndex = 16;
            this.t1337.TabStop = false;
            this.t1337.Text = "Select 1337 File...";
            this.t1337.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.t1337.DragDrop += new System.Windows.Forms.DragEventHandler(this.t1337_DragDrop);
            this.t1337.DragEnter += new System.Windows.Forms.DragEventHandler(this.t1337_DragEnter);
            this.t1337.DoubleClick += new System.EventHandler(this.t1337_DoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkGreen;
            this.label6.Location = new System.Drawing.Point(7, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Exe/Dll File :";
            // 
            // texe
            // 
            this.texe.BackColor = System.Drawing.SystemColors.Info;
            this.texe.ForeColor = System.Drawing.Color.DarkRed;
            this.texe.Location = new System.Drawing.Point(90, 31);
            this.texe.Name = "texe";
            this.texe.ReadOnly = true;
            this.texe.Size = new System.Drawing.Size(370, 20);
            this.texe.TabIndex = 14;
            this.texe.TabStop = false;
            this.texe.Text = "Name of Exe/Dll to Patch...";
            this.texe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSelect1337
            // 
            this.btnSelect1337.CausesValidation = false;
            this.btnSelect1337.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnSelect1337.ForeColor = System.Drawing.Color.DarkRed;
            this.btnSelect1337.Location = new System.Drawing.Point(436, 2);
            this.btnSelect1337.Margin = new System.Windows.Forms.Padding(0);
            this.btnSelect1337.Name = "btnSelect1337";
            this.btnSelect1337.Size = new System.Drawing.Size(24, 23);
            this.btnSelect1337.TabIndex = 19;
            this.btnSelect1337.Text = "...";
            this.btnSelect1337.UseVisualStyleBackColor = true;
            this.btnSelect1337.Click += new System.EventHandler(this.btnSelect1337_Click);
            // 
            // linkdfox
            // 
            this.linkdfox.AutoSize = true;
            this.linkdfox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkdfox.ForeColor = System.Drawing.Color.BlueViolet;
            this.linkdfox.LinkColor = System.Drawing.Color.Indigo;
            this.linkdfox.Location = new System.Drawing.Point(256, 61);
            this.linkdfox.Name = "linkdfox";
            this.linkdfox.Size = new System.Drawing.Size(77, 13);
            this.linkdfox.TabIndex = 73;
            this.linkdfox.TabStop = true;
            this.linkdfox.Text = "By DeltaFoX";
            this.linkdfox.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkdfox_LinkClicked);
            // 
            // Patch
            // 
            this.Patch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Patch.ForeColor = System.Drawing.Color.DarkBlue;
            this.Patch.Location = new System.Drawing.Point(372, 56);
            this.Patch.Name = "Patch";
            this.Patch.Size = new System.Drawing.Size(88, 23);
            this.Patch.TabIndex = 74;
            this.Patch.Text = "Patch";
            this.Patch.UseVisualStyleBackColor = true;
            this.Patch.Click += new System.EventHandler(this.Patch_Click);
            // 
            // controlloBackup
            // 
            this.controlloBackup.AutoSize = true;
            this.controlloBackup.Checked = true;
            this.controlloBackup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.controlloBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.controlloBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.controlloBackup.ForeColor = System.Drawing.Color.Teal;
            this.controlloBackup.Location = new System.Drawing.Point(8, 60);
            this.controlloBackup.Name = "controlloBackup";
            this.controlloBackup.Size = new System.Drawing.Size(69, 17);
            this.controlloBackup.TabIndex = 76;
            this.controlloBackup.Text = "Backup";
            this.controlloBackup.UseVisualStyleBackColor = true;
            this.controlloBackup.CheckedChanged += new System.EventHandler(this.controlloBackup_CheckedChanged);
            // 
            // cfileoffsett
            // 
            this.cfileoffsett.AutoSize = true;
            this.cfileoffsett.Checked = true;
            this.cfileoffsett.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cfileoffsett.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cfileoffsett.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cfileoffsett.ForeColor = System.Drawing.Color.Teal;
            this.cfileoffsett.Location = new System.Drawing.Point(79, 60);
            this.cfileoffsett.Name = "cfileoffsett";
            this.cfileoffsett.Size = new System.Drawing.Size(80, 17);
            this.cfileoffsett.TabIndex = 77;
            this.cfileoffsett.Text = "Fix Offset";
            this.cfileoffsett.UseVisualStyleBackColor = true;
            this.cfileoffsett.CheckedChanged += new System.EventHandler(this.cfileoffsett_CheckedChanged);
            // 
            // cchangeOwnership
            // 
            this.cchangeOwnership.AutoSize = true;
            this.cchangeOwnership.Checked = true;
            this.cchangeOwnership.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cchangeOwnership.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cchangeOwnership.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.cchangeOwnership.ForeColor = System.Drawing.Color.Teal;
            this.cchangeOwnership.Location = new System.Drawing.Point(165, 60);
            this.cchangeOwnership.Name = "cchangeOwnership";
            this.cchangeOwnership.Size = new System.Drawing.Size(93, 17);
            this.cchangeOwnership.TabIndex = 78;
            this.cchangeOwnership.Text = "Unlock DLL";
            this.cchangeOwnership.UseVisualStyleBackColor = true;
            this.cchangeOwnership.CheckedChanged += new System.EventHandler(this.cchangeOwnership_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 83);
            this.Controls.Add(this.cfileoffsett);
            this.Controls.Add(this.controlloBackup);
            this.Controls.Add(this.Patch);
            this.Controls.Add(this.linkdfox);
            this.Controls.Add(this.btnSelect1337);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.t1337);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.texe);
            this.Controls.Add(this.cchangeOwnership);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(488, 122);
            this.MinimumSize = new System.Drawing.Size(488, 122);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Win 1337 Apply Patch File";
            this.Load += new System.EventHandler(this.DFoX_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox t1337;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox texe;
        private System.Windows.Forms.Button btnSelect1337;
        private System.Windows.Forms.LinkLabel linkdfox;
        private System.Windows.Forms.Button Patch;
        private System.Windows.Forms.CheckBox controlloBackup;
        private System.Windows.Forms.CheckBox cfileoffsett;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox cchangeOwnership;
    }
}

