namespace SuperMetroidRandomizer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.softlockHelpCheckbox = new System.Windows.Forms.CheckBox();
            this.FastFanfaresCheckbox = new System.Windows.Forms.CheckBox();
            this.MoreBombsCheckbox = new System.Windows.Forms.CheckBox();
            this.Cycle_Saves_Checkbox = new System.Windows.Forms.CheckBox();
            this.randomSpoiler = new System.Windows.Forms.Button();
            this.browseV11 = new System.Windows.Forms.Button();
            this.seedlabel = new System.Windows.Forms.Label();
            this.outputV11 = new System.Windows.Forms.TextBox();
            this.seedV11 = new System.Windows.Forms.TextBox();
            this.filenameV11 = new System.Windows.Forms.TextBox();
            this.createV11 = new System.Windows.Forms.Button();
            this.outputfilenamelabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // softlockHelpCheckbox
            // 
            this.softlockHelpCheckbox.AutoSize = true;
            this.softlockHelpCheckbox.Checked = true;
            this.softlockHelpCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.softlockHelpCheckbox.Location = new System.Drawing.Point(12, 35);
            this.softlockHelpCheckbox.Name = "softlockHelpCheckbox";
            this.softlockHelpCheckbox.Size = new System.Drawing.Size(154, 17);
            this.softlockHelpCheckbox.TabIndex = 39;
            this.softlockHelpCheckbox.Text = "Prevent Common Softlocks";
            this.softlockHelpCheckbox.UseVisualStyleBackColor = true;
            // 
            // FastFanfaresCheckbox
            // 
            this.FastFanfaresCheckbox.AutoSize = true;
            this.FastFanfaresCheckbox.Checked = true;
            this.FastFanfaresCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FastFanfaresCheckbox.Location = new System.Drawing.Point(191, 35);
            this.FastFanfaresCheckbox.Name = "FastFanfaresCheckbox";
            this.FastFanfaresCheckbox.Size = new System.Drawing.Size(90, 17);
            this.FastFanfaresCheckbox.TabIndex = 38;
            this.FastFanfaresCheckbox.Text = "Fast Fanfares";
            this.FastFanfaresCheckbox.UseVisualStyleBackColor = true;
            // 
            // MoreBombsCheckbox
            // 
            this.MoreBombsCheckbox.AutoSize = true;
            this.MoreBombsCheckbox.Checked = true;
            this.MoreBombsCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MoreBombsCheckbox.Location = new System.Drawing.Point(12, 12);
            this.MoreBombsCheckbox.Name = "MoreBombsCheckbox";
            this.MoreBombsCheckbox.Size = new System.Drawing.Size(141, 17);
            this.MoreBombsCheckbox.TabIndex = 37;
            this.MoreBombsCheckbox.Text = "More Likely Early Bombs";
            this.MoreBombsCheckbox.UseVisualStyleBackColor = true;
            // 
            // Cycle_Saves_Checkbox
            // 
            this.Cycle_Saves_Checkbox.AutoSize = true;
            this.Cycle_Saves_Checkbox.Checked = true;
            this.Cycle_Saves_Checkbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Cycle_Saves_Checkbox.Location = new System.Drawing.Point(191, 12);
            this.Cycle_Saves_Checkbox.Name = "Cycle_Saves_Checkbox";
            this.Cycle_Saves_Checkbox.Size = new System.Drawing.Size(121, 17);
            this.Cycle_Saves_Checkbox.TabIndex = 36;
            this.Cycle_Saves_Checkbox.Text = "Auto Backup Saves";
            this.Cycle_Saves_Checkbox.UseVisualStyleBackColor = true;
            this.Cycle_Saves_Checkbox.CheckedChanged += new System.EventHandler(this.Cycle_Saves_Checkbox_CheckedChanged);
            // 
            // randomSpoiler
            // 
            this.randomSpoiler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.randomSpoiler.Location = new System.Drawing.Point(353, 77);
            this.randomSpoiler.Name = "randomSpoiler";
            this.randomSpoiler.Size = new System.Drawing.Size(100, 23);
            this.randomSpoiler.TabIndex = 35;
            this.randomSpoiler.Text = "Random Spoiler";
            this.randomSpoiler.UseVisualStyleBackColor = true;
            this.randomSpoiler.Click += new System.EventHandler(this.randomSpoiler_Click);
            // 
            // browseV11
            // 
            this.browseV11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseV11.Image = global::SuperMetroidRandomizer.Properties.Resources.MenuFileSaveIcon;
            this.browseV11.Location = new System.Drawing.Point(428, 129);
            this.browseV11.Name = "browseV11";
            this.browseV11.Size = new System.Drawing.Size(25, 25);
            this.browseV11.TabIndex = 15;
            this.browseV11.UseVisualStyleBackColor = true;
            this.browseV11.Click += new System.EventHandler(this.browseV11_Click);
            // 
            // seedlabel
            // 
            this.seedlabel.AutoSize = true;
            this.seedlabel.Location = new System.Drawing.Point(9, 64);
            this.seedlabel.Name = "seedlabel";
            this.seedlabel.Size = new System.Drawing.Size(242, 13);
            this.seedlabel.TabIndex = 17;
            this.seedlabel.Text = "Seed (leave blank to generate new random ROM)";
            // 
            // outputV11
            // 
            this.outputV11.AcceptsReturn = true;
            this.outputV11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputV11.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputV11.Location = new System.Drawing.Point(12, 172);
            this.outputV11.Multiline = true;
            this.outputV11.Name = "outputV11";
            this.outputV11.ReadOnly = true;
            this.outputV11.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.outputV11.Size = new System.Drawing.Size(437, 190);
            this.outputV11.TabIndex = 10;
            // 
            // seedV11
            // 
            this.seedV11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.seedV11.Location = new System.Drawing.Point(12, 80);
            this.seedV11.Name = "seedV11";
            this.seedV11.Size = new System.Drawing.Size(335, 20);
            this.seedV11.TabIndex = 16;
            // 
            // filenameV11
            // 
            this.filenameV11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filenameV11.Location = new System.Drawing.Point(12, 134);
            this.filenameV11.Name = "filenameV11";
            this.filenameV11.Size = new System.Drawing.Size(410, 20);
            this.filenameV11.TabIndex = 14;
            this.filenameV11.Text = "SM_Redesign_<seed>.sfc";
            this.filenameV11.TextChanged += new System.EventHandler(this.filenameV11_TextChanged);
            this.filenameV11.Leave += new System.EventHandler(this.filename_Leave);
            // 
            // createV11
            // 
            this.createV11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.createV11.Location = new System.Drawing.Point(378, 6);
            this.createV11.Name = "createV11";
            this.createV11.Size = new System.Drawing.Size(75, 23);
            this.createV11.TabIndex = 11;
            this.createV11.Text = "Create";
            this.createV11.UseVisualStyleBackColor = true;
            this.createV11.Click += new System.EventHandler(this.createV11_Click);
            // 
            // outputfilenamelabel
            // 
            this.outputfilenamelabel.AutoSize = true;
            this.outputfilenamelabel.Location = new System.Drawing.Point(12, 118);
            this.outputfilenamelabel.Name = "outputfilenamelabel";
            this.outputfilenamelabel.Size = new System.Drawing.Size(385, 13);
            this.outputfilenamelabel.TabIndex = 13;
            this.outputfilenamelabel.Text = "Output Filename (<seed> is replaced with file seed, <date> is replaced with date)" +
    "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 374);
            this.Controls.Add(this.outputfilenamelabel);
            this.Controls.Add(this.createV11);
            this.Controls.Add(this.filenameV11);
            this.Controls.Add(this.seedV11);
            this.Controls.Add(this.outputV11);
            this.Controls.Add(this.seedlabel);
            this.Controls.Add(this.browseV11);
            this.Controls.Add(this.randomSpoiler);
            this.Controls.Add(this.Cycle_Saves_Checkbox);
            this.Controls.Add(this.MoreBombsCheckbox);
            this.Controls.Add(this.FastFanfaresCheckbox);
            this.Controls.Add(this.softlockHelpCheckbox);
            this.Name = "MainForm";
            this.Text = "Super Metroid: Redesign Randomizer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button randomSpoiler;
        private System.Windows.Forms.Button browseV11;
        private System.Windows.Forms.Label seedlabel;
        private System.Windows.Forms.TextBox outputV11;
        private System.Windows.Forms.TextBox seedV11;
        private System.Windows.Forms.TextBox filenameV11;
        private System.Windows.Forms.Button createV11;
        private System.Windows.Forms.Label outputfilenamelabel;
        private System.Windows.Forms.CheckBox Cycle_Saves_Checkbox;
        private System.Windows.Forms.CheckBox MoreBombsCheckbox;
        private System.Windows.Forms.CheckBox FastFanfaresCheckbox;
        private System.Windows.Forms.CheckBox softlockHelpCheckbox;
    }
}

