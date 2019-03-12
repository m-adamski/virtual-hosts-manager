namespace VirtualHostsManager
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            this.configButton = new System.Windows.Forms.Button();
            this.templateButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.configInfoPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.configInfoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // configButton
            // 
            this.configButton.Location = new System.Drawing.Point(12, 415);
            this.configButton.Name = "configButton";
            this.configButton.Size = new System.Drawing.Size(156, 23);
            this.configButton.TabIndex = 0;
            this.configButton.Text = "Configuration";
            this.configButton.UseVisualStyleBackColor = true;
            this.configButton.Click += new System.EventHandler(this.configButton_Click);
            // 
            // templateButton
            // 
            this.templateButton.Location = new System.Drawing.Point(174, 415);
            this.templateButton.Name = "templateButton";
            this.templateButton.Size = new System.Drawing.Size(156, 23);
            this.templateButton.TabIndex = 1;
            this.templateButton.Text = "Template";
            this.templateButton.UseVisualStyleBackColor = true;
            this.templateButton.Click += new System.EventHandler(this.templateButton_Click);
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(713, 415);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(75, 23);
            this.createButton.TabIndex = 2;
            this.createButton.Text = "Create";
            this.createButton.UseVisualStyleBackColor = true;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // configInfoPictureBox
            // 
            this.configInfoPictureBox.Image = global::VirtualHostsManager.Properties.Resources.info_icon;
            this.configInfoPictureBox.Location = new System.Drawing.Point(691, 415);
            this.configInfoPictureBox.Name = "configInfoPictureBox";
            this.configInfoPictureBox.Size = new System.Drawing.Size(16, 23);
            this.configInfoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.configInfoPictureBox.TabIndex = 3;
            this.configInfoPictureBox.TabStop = false;
            this.toolTip.SetToolTip(this.configInfoPictureBox, "To create a new virtual host configuration, you first need to complete the config" +
        "uration");
            this.configInfoPictureBox.Visible = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.configInfoPictureBox);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.templateButton);
            this.Controls.Add(this.configButton);
            this.Name = "MainWindow";
            this.Text = "Virtual Hosts Manager";
            this.Activated += new System.EventHandler(this.MainWindow_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.configInfoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button configButton;
        private System.Windows.Forms.Button templateButton;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.PictureBox configInfoPictureBox;
    }
}

