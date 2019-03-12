﻿namespace VirtualHostsManager
{
    partial class CreateWindow
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
            this.hostListView = new BrightIdeasSoftware.ObjectListView();
            this.domainNameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.directoryColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.button1 = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.contentEditor = new ScintillaNET.Scintilla();
            ((System.ComponentModel.ISupportInitialize)(this.hostListView)).BeginInit();
            this.SuspendLayout();
            // 
            // hostListView
            // 
            this.hostListView.AllColumns.Add(this.domainNameColumn);
            this.hostListView.AllColumns.Add(this.directoryColumn);
            this.hostListView.CellEditUseWholeCell = false;
            this.hostListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.domainNameColumn,
            this.directoryColumn});
            this.hostListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.hostListView.FullRowSelect = true;
            this.hostListView.Location = new System.Drawing.Point(12, 12);
            this.hostListView.MultiSelect = false;
            this.hostListView.Name = "hostListView";
            this.hostListView.ShowGroups = false;
            this.hostListView.Size = new System.Drawing.Size(660, 135);
            this.hostListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.hostListView.TabIndex = 0;
            this.hostListView.UseCompatibleStateImageBehavior = false;
            this.hostListView.View = System.Windows.Forms.View.Details;
            this.hostListView.SelectionChanged += new System.EventHandler(this.hostListView_SelectionChanged);
            // 
            // domainNameColumn
            // 
            this.domainNameColumn.AspectName = "Domain";
            this.domainNameColumn.Text = "Domain";
            this.domainNameColumn.Width = 200;
            // 
            // directoryColumn
            // 
            this.directoryColumn.AspectName = "DirectoryPath";
            this.directoryColumn.Text = "Directory";
            this.directoryColumn.Width = 420;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(597, 526);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(516, 526);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // contentEditor
            // 
            this.contentEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.contentEditor.Location = new System.Drawing.Point(12, 153);
            this.contentEditor.Name = "contentEditor";
            this.contentEditor.ScrollWidth = 630;
            this.contentEditor.Size = new System.Drawing.Size(660, 367);
            this.contentEditor.TabIndex = 3;
            this.contentEditor.Text = "Select the domain to create the virtual host configuration";
            // 
            // CreateWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.contentEditor);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.hostListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateWindow";
            this.Text = "Create";
            ((System.ComponentModel.ISupportInitialize)(this.hostListView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView hostListView;
        private BrightIdeasSoftware.OLVColumn domainNameColumn;
        private BrightIdeasSoftware.OLVColumn directoryColumn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button cancelButton;
        private ScintillaNET.Scintilla contentEditor;
    }
}