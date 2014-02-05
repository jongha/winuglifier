namespace WinUglifier
{
    partial class Main
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
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnUglify = new System.Windows.Forms.Button();
            this.listFiles = new System.Windows.Forms.ListView();
            this.colDirectory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSelect = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnUglify
            // 
            this.btnUglify.Location = new System.Drawing.Point(12, 191);
            this.btnUglify.Name = "btnUglify";
            this.btnUglify.Size = new System.Drawing.Size(332, 37);
            this.btnUglify.TabIndex = 3;
            this.btnUglify.Text = "Uglify Now";
            this.btnUglify.UseVisualStyleBackColor = true;
            this.btnUglify.Click += new System.EventHandler(this.btnUglify_Click);
            // 
            // listFiles
            // 
            this.listFiles.AllowDrop = true;
            this.listFiles.CheckBoxes = true;
            this.listFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSelect,
            this.colDirectory,
            this.colName});
            this.listFiles.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.listFiles.FullRowSelect = true;
            this.listFiles.GridLines = true;
            this.listFiles.Location = new System.Drawing.Point(12, 12);
            this.listFiles.Name = "listFiles";
            this.listFiles.Size = new System.Drawing.Size(332, 173);
            this.listFiles.TabIndex = 5;
            this.listFiles.UseCompatibleStateImageBehavior = false;
            this.listFiles.View = System.Windows.Forms.View.Details;
            this.listFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.listFiles_DragDrop);
            this.listFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.listFiles_DragEnter);
            this.listFiles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listFiles_KeyDown);
            // 
            // colDirectory
            // 
            this.colDirectory.Text = "Directory";
            // 
            // colName
            // 
            this.colName.Text = "Name";
            // 
            // colSelect
            // 
            this.colSelect.DisplayIndex = 0;
            this.colSelect.Text = "#";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 237);
            this.Controls.Add(this.listFiles);
            this.Controls.Add(this.btnUglify);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Main";
            this.Text = "WinUglifier";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button btnUglify;
        private System.Windows.Forms.ListView listFiles;
        private System.Windows.Forms.ColumnHeader colDirectory;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colSelect;
    }
}

