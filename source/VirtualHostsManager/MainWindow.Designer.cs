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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.configButton = new System.Windows.Forms.Button();
            this.templateButton = new System.Windows.Forms.Button();
            this.createButton = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.configInfoPictureBox = new System.Windows.Forms.PictureBox();
            this.hostListView = new BrightIdeasSoftware.ObjectListView();
            this.domainColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.directoryColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.scanButton = new System.Windows.Forms.Button();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.configInfoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hostListView)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
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
            this.configInfoPictureBox.Location = new System.Drawing.Point(610, 415);
            this.configInfoPictureBox.Name = "configInfoPictureBox";
            this.configInfoPictureBox.Size = new System.Drawing.Size(16, 23);
            this.configInfoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.configInfoPictureBox.TabIndex = 3;
            this.configInfoPictureBox.TabStop = false;
            this.toolTip.SetToolTip(this.configInfoPictureBox, "Complete the configuration before you can scan and create new virtual hosts");
            this.configInfoPictureBox.Visible = false;
            // 
            // hostListView
            // 
            this.hostListView.AllColumns.Add(this.domainColumn);
            this.hostListView.AllColumns.Add(this.directoryColumn);
            this.hostListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hostListView.CellEditUseWholeCell = false;
            this.hostListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.domainColumn,
            this.directoryColumn});
            this.hostListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.hostListView.FullRowSelect = true;
            this.hostListView.Location = new System.Drawing.Point(12, 12);
            this.hostListView.MultiSelect = false;
            this.hostListView.Name = "hostListView";
            this.hostListView.ShowGroups = false;
            this.hostListView.Size = new System.Drawing.Size(776, 397);
            this.hostListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.hostListView.TabIndex = 4;
            this.hostListView.UseCompatibleStateImageBehavior = false;
            this.hostListView.View = System.Windows.Forms.View.Details;
            this.hostListView.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.hostListView_CellRightClick);
            this.hostListView.SelectionChanged += new System.EventHandler(this.hostListView_SelectionChanged);
            // 
            // domainColumn
            // 
            this.domainColumn.AspectName = "Domain";
            this.domainColumn.Text = "Domain";
            this.domainColumn.Width = 200;
            // 
            // directoryColumn
            // 
            this.directoryColumn.AspectName = "DirectoryPath";
            this.directoryColumn.Text = "Directory";
            this.directoryColumn.Width = 550;
            // 
            // scanButton
            // 
            this.scanButton.Location = new System.Drawing.Point(632, 415);
            this.scanButton.Name = "scanButton";
            this.scanButton.Size = new System.Drawing.Size(75, 23);
            this.scanButton.TabIndex = 5;
            this.scanButton.Text = "Scan";
            this.scanButton.UseVisualStyleBackColor = true;
            this.scanButton.Click += new System.EventHandler(this.scanButton_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editStripMenuItem,
            this.removeStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(118, 48);
            // 
            // editStripMenuItem
            // 
            this.editStripMenuItem.Name = "editStripMenuItem";
            this.editStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.editStripMenuItem.Text = "Edit";
            this.editStripMenuItem.Click += new System.EventHandler(this.editStripMenuItem_Click);
            // 
            // removeStripMenuItem
            // 
            this.removeStripMenuItem.Name = "removeStripMenuItem";
            this.removeStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.removeStripMenuItem.Text = "Remove";
            this.removeStripMenuItem.Click += new System.EventHandler(this.removeStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.scanButton);
            this.Controls.Add(this.hostListView);
            this.Controls.Add(this.configInfoPictureBox);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.templateButton);
            this.Controls.Add(this.configButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.Text = "Virtual Hosts Manager";
            this.Activated += new System.EventHandler(this.MainWindow_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.configInfoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hostListView)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button configButton;
        private System.Windows.Forms.Button templateButton;
        private System.Windows.Forms.Button createButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.PictureBox configInfoPictureBox;
        private BrightIdeasSoftware.ObjectListView hostListView;
        private BrightIdeasSoftware.OLVColumn domainColumn;
        private BrightIdeasSoftware.OLVColumn directoryColumn;
        private System.Windows.Forms.Button scanButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem editStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeStripMenuItem;
    }
}

