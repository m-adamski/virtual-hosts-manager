namespace VirtualHostsManager
{
    partial class RemoveWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoveWindow));
            this.infooLabel = new System.Windows.Forms.Label();
            this.configurationCheckBox = new System.Windows.Forms.CheckBox();
            this.directoryCheckBox = new System.Windows.Forms.CheckBox();
            this.entryCheckBox = new System.Windows.Forms.CheckBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.infoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // infooLabel
            // 
            this.infooLabel.AutoSize = true;
            this.infooLabel.Location = new System.Drawing.Point(12, 27);
            this.infooLabel.Name = "infooLabel";
            this.infooLabel.Size = new System.Drawing.Size(233, 13);
            this.infooLabel.TabIndex = 0;
            this.infooLabel.Text = "Please select the elements that will be removed:";
            // 
            // configurationCheckBox
            // 
            this.configurationCheckBox.AutoSize = true;
            this.configurationCheckBox.Checked = true;
            this.configurationCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.configurationCheckBox.Enabled = false;
            this.configurationCheckBox.Location = new System.Drawing.Point(34, 58);
            this.configurationCheckBox.Name = "configurationCheckBox";
            this.configurationCheckBox.Size = new System.Drawing.Size(104, 17);
            this.configurationCheckBox.TabIndex = 1;
            this.configurationCheckBox.Text = "Configuration file";
            this.configurationCheckBox.UseVisualStyleBackColor = true;
            // 
            // directoryCheckBox
            // 
            this.directoryCheckBox.AutoSize = true;
            this.directoryCheckBox.Location = new System.Drawing.Point(34, 81);
            this.directoryCheckBox.Name = "directoryCheckBox";
            this.directoryCheckBox.Size = new System.Drawing.Size(122, 17);
            this.directoryCheckBox.TabIndex = 2;
            this.directoryCheckBox.Text = "Subdomain directory";
            this.directoryCheckBox.UseVisualStyleBackColor = true;
            // 
            // entryCheckBox
            // 
            this.entryCheckBox.AutoSize = true;
            this.entryCheckBox.Location = new System.Drawing.Point(34, 104);
            this.entryCheckBox.Name = "entryCheckBox";
            this.entryCheckBox.Size = new System.Drawing.Size(173, 17);
            this.entryCheckBox.TabIndex = 3;
            this.entryCheckBox.Text = "An entry in the system hosts file";
            this.entryCheckBox.UseVisualStyleBackColor = true;
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(317, 146);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 4;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(236, 146);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(12, 9);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(297, 13);
            this.infoLabel.TabIndex = 6;
            this.infoLabel.Text = "A confirmation is required to delete the selected configuration.";
            // 
            // RemoveWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(404, 181);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.entryCheckBox);
            this.Controls.Add(this.directoryCheckBox);
            this.Controls.Add(this.configurationCheckBox);
            this.Controls.Add(this.infooLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RemoveWindow";
            this.Text = "Remove";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label infooLabel;
        private System.Windows.Forms.CheckBox configurationCheckBox;
        private System.Windows.Forms.CheckBox directoryCheckBox;
        private System.Windows.Forms.CheckBox entryCheckBox;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label infoLabel;
    }
}