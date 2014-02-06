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
            this.treeItems = new System.Windows.Forms.TreeView();
            this.chkCSS = new System.Windows.Forms.CheckBox();
            this.comboAlgorithms = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkJavascript = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rdoOverwrite = new System.Windows.Forms.RadioButton();
            this.rdoRename = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUglify
            // 
            this.btnUglify.Location = new System.Drawing.Point(383, 393);
            this.btnUglify.Name = "btnUglify";
            this.btnUglify.Size = new System.Drawing.Size(160, 37);
            this.btnUglify.TabIndex = 3;
            this.btnUglify.Text = "Uglify";
            this.btnUglify.UseVisualStyleBackColor = true;
            this.btnUglify.Click += new System.EventHandler(this.btnUglify_Click);
            // 
            // treeItems
            // 
            this.treeItems.AllowDrop = true;
            this.treeItems.ItemHeight = 20;
            this.treeItems.Location = new System.Drawing.Point(6, 20);
            this.treeItems.Name = "treeItems";
            this.treeItems.Size = new System.Drawing.Size(519, 242);
            this.treeItems.TabIndex = 6;
            this.treeItems.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeItems_DragDrop);
            this.treeItems.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeItems_DragEnter);
            this.treeItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeItems_KeyDown);
            // 
            // chkCSS
            // 
            this.chkCSS.AutoSize = true;
            this.chkCSS.Checked = true;
            this.chkCSS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCSS.Location = new System.Drawing.Point(89, 46);
            this.chkCSS.Name = "chkCSS";
            this.chkCSS.Size = new System.Drawing.Size(49, 16);
            this.chkCSS.TabIndex = 7;
            this.chkCSS.Text = "CSS";
            this.chkCSS.UseVisualStyleBackColor = true;
            // 
            // comboAlgorithms
            // 
            this.comboAlgorithms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAlgorithms.FormattingEnabled = true;
            this.comboAlgorithms.Location = new System.Drawing.Point(89, 17);
            this.comboAlgorithms.Name = "comboAlgorithms";
            this.comboAlgorithms.Size = new System.Drawing.Size(121, 20);
            this.comboAlgorithms.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoRename);
            this.groupBox1.Controls.Add(this.rdoOverwrite);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.chkJavascript);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboAlgorithms);
            this.groupBox1.Controls.Add(this.chkCSS);
            this.groupBox1.Location = new System.Drawing.Point(12, 286);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(531, 100);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.treeItems);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(531, 268);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Drag && Drop Files or Directories";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "Algorithms";
            // 
            // chkJavascript
            // 
            this.chkJavascript.AutoSize = true;
            this.chkJavascript.Checked = true;
            this.chkJavascript.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkJavascript.Location = new System.Drawing.Point(144, 46);
            this.chkJavascript.Name = "chkJavascript";
            this.chkJavascript.Size = new System.Drawing.Size(81, 16);
            this.chkJavascript.TabIndex = 10;
            this.chkJavascript.Text = "Javascript";
            this.chkJavascript.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "Modes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "Output";
            // 
            // rdoOverwrite
            // 
            this.rdoOverwrite.AutoSize = true;
            this.rdoOverwrite.Location = new System.Drawing.Point(89, 72);
            this.rdoOverwrite.Name = "rdoOverwrite";
            this.rdoOverwrite.Size = new System.Drawing.Size(76, 16);
            this.rdoOverwrite.TabIndex = 13;
            this.rdoOverwrite.Text = "Overwrite";
            this.rdoOverwrite.UseVisualStyleBackColor = true;
            // 
            // rdoRename
            // 
            this.rdoRename.AutoSize = true;
            this.rdoRename.Checked = true;
            this.rdoRename.Location = new System.Drawing.Point(173, 72);
            this.rdoRename.Name = "rdoRename";
            this.rdoRename.Size = new System.Drawing.Size(70, 16);
            this.rdoRename.TabIndex = 13;
            this.rdoRename.TabStop = true;
            this.rdoRename.Text = "Rename";
            this.rdoRename.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 477);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnUglify);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Main";
            this.Text = "WinUglifier";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button btnUglify;
        private System.Windows.Forms.TreeView treeItems;
        private System.Windows.Forms.CheckBox chkCSS;
        private System.Windows.Forms.ComboBox comboAlgorithms;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkJavascript;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdoRename;
        private System.Windows.Forms.RadioButton rdoOverwrite;
    }
}

