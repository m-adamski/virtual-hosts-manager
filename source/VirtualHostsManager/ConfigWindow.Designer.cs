namespace VirtualHostsManager
{
    partial class ConfigWindow
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.configListView = new BrightIdeasSoftware.ObjectListView();
            this.nameColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.valueColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.saveButton = new System.Windows.Forms.Button();
            this.infoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.configListView)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(516, 326);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // configListView
            // 
            this.configListView.AllColumns.Add(this.nameColumn);
            this.configListView.AllColumns.Add(this.valueColumn);
            this.configListView.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.configListView.CellEditUseWholeCell = false;
            this.configListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumn,
            this.valueColumn});
            this.configListView.Cursor = System.Windows.Forms.Cursors.Default;
            this.configListView.FullRowSelect = true;
            this.configListView.HasCollapsibleGroups = false;
            this.configListView.Location = new System.Drawing.Point(12, 12);
            this.configListView.MultiSelect = false;
            this.configListView.Name = "configListView";
            this.configListView.ShowGroups = false;
            this.configListView.Size = new System.Drawing.Size(660, 308);
            this.configListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.configListView.TabIndex = 2;
            this.configListView.UseCompatibleStateImageBehavior = false;
            this.configListView.View = System.Windows.Forms.View.Details;
            // 
            // nameColumn
            // 
            this.nameColumn.AspectName = "Description";
            this.nameColumn.IsEditable = false;
            this.nameColumn.Text = "Name";
            this.nameColumn.Width = 200;
            // 
            // valueColumn
            // 
            this.valueColumn.AspectName = "Value";
            this.valueColumn.Text = "Value";
            this.valueColumn.Width = 450;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(597, 326);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(12, 331);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(262, 13);
            this.infoLabel.TabIndex = 4;
            this.infoLabel.Text = "Double click on the selected item to change the value";
            // 
            // ConfigWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(684, 361);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.configListView);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigWindow";
            this.Text = "Config";
            ((System.ComponentModel.ISupportInitialize)(this.configListView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cancelButton;
        private BrightIdeasSoftware.ObjectListView configListView;
        private BrightIdeasSoftware.OLVColumn nameColumn;
        private BrightIdeasSoftware.OLVColumn valueColumn;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label infoLabel;
    }
}