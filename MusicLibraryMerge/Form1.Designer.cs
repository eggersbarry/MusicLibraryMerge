namespace MusicLibraryMerge
{
    partial class Form1
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
			this.button1 = new System.Windows.Forms.Button();
			this.rtb1 = new System.Windows.Forms.RichTextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.btnfirstfolder = new System.Windows.Forms.Button();
			this.tbfirstfolder = new System.Windows.Forms.TextBox();
			this.btnClose = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.filesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.startFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.finalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.tbsecondfolder = new System.Windows.Forms.TextBox();
			this.tmatch = new System.Windows.Forms.TextBox();
			this.tignore = new System.Windows.Forms.TextBox();
			this.tsub = new System.Windows.Forms.TextBox();
			this.tfind = new System.Windows.Forms.TextBox();
			this.btnsecondfolder = new System.Windows.Forms.Button();
			this.btnMerge = new System.Windows.Forms.Button();
			this.lblfound = new System.Windows.Forms.Label();
			this.btnTrim = new System.Windows.Forms.Button();
			this.btnfixdisc = new System.Windows.Forms.Button();
			this.btnReplace = new System.Windows.Forms.Button();
			this.lblmatch = new System.Windows.Forms.Label();
			this.lblignore = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnbraces = new System.Windows.Forms.Button();
			this.btnemptyfolders = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(621, 36);
			this.button1.Margin = new System.Windows.Forms.Padding(4);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(112, 23);
			this.button1.TabIndex = 7;
			this.button1.Text = "recursive";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// rtb1
			// 
			this.rtb1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rtb1.Location = new System.Drawing.Point(6, 212);
			this.rtb1.Margin = new System.Windows.Forms.Padding(4);
			this.rtb1.Name = "rtb1";
			this.rtb1.Size = new System.Drawing.Size(726, 241);
			this.rtb1.TabIndex = 17;
			this.rtb1.Text = "";
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Location = new System.Drawing.Point(621, 63);
			this.button2.Margin = new System.Windows.Forms.Padding(4);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(112, 23);
			this.button2.TabIndex = 8;
			this.button2.Text = "non-recursive";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// btnfirstfolder
			// 
			this.btnfirstfolder.Location = new System.Drawing.Point(12, 32);
			this.btnfirstfolder.Name = "btnfirstfolder";
			this.btnfirstfolder.Size = new System.Drawing.Size(106, 23);
			this.btnfirstfolder.TabIndex = 1;
			this.btnfirstfolder.Text = "&Start Folder";
			this.btnfirstfolder.UseVisualStyleBackColor = true;
			this.btnfirstfolder.Click += new System.EventHandler(this.btnfirstfolder_Click);
			// 
			// tbfirstfolder
			// 
			this.tbfirstfolder.AllowDrop = true;
			this.tbfirstfolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbfirstfolder.Location = new System.Drawing.Point(125, 34);
			this.tbfirstfolder.Name = "tbfirstfolder";
			this.tbfirstfolder.Size = new System.Drawing.Size(491, 23);
			this.tbfirstfolder.TabIndex = 2;
			this.toolTip1.SetToolTip(this.tbfirstfolder, "TopLevel Folder to Start The Search");
			this.tbfirstfolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbfolder_DragDrop);
			this.tbfirstfolder.DragEnter += new System.Windows.Forms.DragEventHandler(this.tbfolder_DragEnter);
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.Location = new System.Drawing.Point(652, 460);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 25);
			this.btnClose.TabIndex = 14;
			this.btnClose.Text = "E&xit";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(739, 24);
			this.menuStrip1.TabIndex = 8;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// filesToolStripMenuItem
			// 
			this.filesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startFolderToolStripMenuItem,
            this.finalToolStripMenuItem,
            this.exitToolStripMenuItem1});
			this.filesToolStripMenuItem.Name = "filesToolStripMenuItem";
			this.filesToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
			this.filesToolStripMenuItem.Text = "&Files";
			// 
			// startFolderToolStripMenuItem
			// 
			this.startFolderToolStripMenuItem.Name = "startFolderToolStripMenuItem";
			this.startFolderToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			this.startFolderToolStripMenuItem.Text = "&Source Folder";
			this.startFolderToolStripMenuItem.Click += new System.EventHandler(this.startFolderToolStripMenuItem_Click);
			// 
			// finalToolStripMenuItem
			// 
			this.finalToolStripMenuItem.Name = "finalToolStripMenuItem";
			this.finalToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
			this.finalToolStripMenuItem.Text = "Destination Folder";
			this.finalToolStripMenuItem.Click += new System.EventHandler(this.finalToolStripMenuItem_Click);
			// 
			// exitToolStripMenuItem1
			// 
			this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
			this.exitToolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
			this.exitToolStripMenuItem1.Text = "E&xit";
			this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
			// 
			// toolTip1
			// 
			this.toolTip1.AutoPopDelay = 3000;
			this.toolTip1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.toolTip1.ForeColor = System.Drawing.SystemColors.Info;
			this.toolTip1.InitialDelay = 500;
			this.toolTip1.ReshowDelay = 100;
			// 
			// tbsecondfolder
			// 
			this.tbsecondfolder.AllowDrop = true;
			this.tbsecondfolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbsecondfolder.Location = new System.Drawing.Point(125, 63);
			this.tbsecondfolder.Name = "tbsecondfolder";
			this.tbsecondfolder.Size = new System.Drawing.Size(491, 23);
			this.tbsecondfolder.TabIndex = 4;
			this.toolTip1.SetToolTip(this.tbsecondfolder, "TopLevel Folder to Compare to Start Folder for Duplicates");
			this.tbsecondfolder.DragDrop += new System.Windows.Forms.DragEventHandler(this.tbfolder_DragDrop);
			this.tbsecondfolder.DragEnter += new System.Windows.Forms.DragEventHandler(this.tbfolder_DragEnter);
			// 
			// tmatch
			// 
			this.tmatch.Location = new System.Drawing.Point(480, 91);
			this.tmatch.Name = "tmatch";
			this.tmatch.Size = new System.Drawing.Size(250, 23);
			this.tmatch.TabIndex = 9;
			this.toolTip1.SetToolTip(this.tmatch, " Characters to be Replaced");
			// 
			// tignore
			// 
			this.tignore.Location = new System.Drawing.Point(101, 120);
			this.tignore.Name = "tignore";
			this.tignore.Size = new System.Drawing.Size(180, 23);
			this.tignore.TabIndex = 6;
			this.toolTip1.SetToolTip(this.tignore, "Characters to be Ignored on Search");
			// 
			// tsub
			// 
			this.tsub.Location = new System.Drawing.Point(480, 120);
			this.tsub.Name = "tsub";
			this.tsub.Size = new System.Drawing.Size(250, 23);
			this.tsub.TabIndex = 10;
			this.toolTip1.SetToolTip(this.tsub, "Characters to Substitute in on Replacement");
			// 
			// tfind
			// 
			this.tfind.Location = new System.Drawing.Point(101, 91);
			this.tfind.Name = "tfind";
			this.tfind.Size = new System.Drawing.Size(180, 23);
			this.tfind.TabIndex = 5;
			this.toolTip1.SetToolTip(this.tfind, "Mask to match on Search");
			// 
			// btnsecondfolder
			// 
			this.btnsecondfolder.Location = new System.Drawing.Point(12, 61);
			this.btnsecondfolder.Name = "btnsecondfolder";
			this.btnsecondfolder.Size = new System.Drawing.Size(106, 23);
			this.btnsecondfolder.TabIndex = 3;
			this.btnsecondfolder.Text = "&Dest Folder";
			this.btnsecondfolder.UseVisualStyleBackColor = true;
			this.btnsecondfolder.Click += new System.EventHandler(this.btnsecondfolder_Click);
			// 
			// btnMerge
			// 
			this.btnMerge.Location = new System.Drawing.Point(12, 146);
			this.btnMerge.Name = "btnMerge";
			this.btnMerge.Size = new System.Drawing.Size(75, 25);
			this.btnMerge.TabIndex = 16;
			this.btnMerge.Text = "&Merge";
			this.btnMerge.UseVisualStyleBackColor = true;
			this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
			// 
			// lblfound
			// 
			this.lblfound.AutoSize = true;
			this.lblfound.Location = new System.Drawing.Point(287, 96);
			this.lblfound.Name = "lblfound";
			this.lblfound.Size = new System.Drawing.Size(46, 16);
			this.lblfound.TabIndex = 16;
			this.lblfound.Text = "label1";
			// 
			// btnTrim
			// 
			this.btnTrim.Location = new System.Drawing.Point(406, 180);
			this.btnTrim.Name = "btnTrim";
			this.btnTrim.Size = new System.Drawing.Size(75, 25);
			this.btnTrim.TabIndex = 14;
			this.btnTrim.Text = "&Trim";
			this.btnTrim.UseVisualStyleBackColor = true;
			this.btnTrim.Click += new System.EventHandler(this.btnTrim_Click);
			// 
			// btnfixdisc
			// 
			this.btnfixdisc.Location = new System.Drawing.Point(654, 149);
			this.btnfixdisc.Name = "btnfixdisc";
			this.btnfixdisc.Size = new System.Drawing.Size(75, 25);
			this.btnfixdisc.TabIndex = 13;
			this.btnfixdisc.Text = "&fix&Disc";
			this.btnfixdisc.UseVisualStyleBackColor = true;
			this.btnfixdisc.Click += new System.EventHandler(this.btnfixdisc_Click);
			// 
			// btnReplace
			// 
			this.btnReplace.Location = new System.Drawing.Point(406, 149);
			this.btnReplace.Name = "btnReplace";
			this.btnReplace.Size = new System.Drawing.Size(75, 25);
			this.btnReplace.TabIndex = 11;
			this.btnReplace.Text = "&Replace";
			this.btnReplace.UseVisualStyleBackColor = true;
			this.btnReplace.Click += new System.EventHandler(this.btnReplace_Click);
			// 
			// lblmatch
			// 
			this.lblmatch.AutoSize = true;
			this.lblmatch.Location = new System.Drawing.Point(390, 98);
			this.lblmatch.Name = "lblmatch";
			this.lblmatch.Size = new System.Drawing.Size(91, 16);
			this.lblmatch.TabIndex = 20;
			this.lblmatch.Text = "Replace This";
			// 
			// lblignore
			// 
			this.lblignore.AutoSize = true;
			this.lblignore.Location = new System.Drawing.Point(411, 127);
			this.lblignore.Name = "lblignore";
			this.lblignore.Size = new System.Drawing.Size(70, 16);
			this.lblignore.TabIndex = 21;
			this.lblignore.Text = "With This";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 127);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(82, 16);
			this.label1.TabIndex = 25;
			this.label1.Text = "Ignore This";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 98);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(67, 16);
			this.label2.TabIndex = 24;
			this.label2.Text = "Find This";
			// 
			// btnbraces
			// 
			this.btnbraces.Location = new System.Drawing.Point(497, 149);
			this.btnbraces.Name = "btnbraces";
			this.btnbraces.Size = new System.Drawing.Size(139, 25);
			this.btnbraces.TabIndex = 12;
			this.btnbraces.Text = "&Remove Between";
			this.btnbraces.UseVisualStyleBackColor = true;
			this.btnbraces.Click += new System.EventHandler(this.btnbraces_Click);
			// 
			// btnemptyfolders
			// 
			this.btnemptyfolders.Location = new System.Drawing.Point(497, 180);
			this.btnemptyfolders.Name = "btnemptyfolders";
			this.btnemptyfolders.Size = new System.Drawing.Size(139, 25);
			this.btnemptyfolders.TabIndex = 15;
			this.btnemptyfolders.Text = "&Empty Folders";
			this.btnemptyfolders.UseVisualStyleBackColor = true;
			this.btnemptyfolders.Click += new System.EventHandler(this.btnemptyfolders_Click);
			// 
			// Form1
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.PaleGoldenrod;
			this.ClientSize = new System.Drawing.Size(739, 486);
			this.Controls.Add(this.btnemptyfolders);
			this.Controls.Add(this.btnbraces);
			this.Controls.Add(this.tsub);
			this.Controls.Add(this.tfind);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tignore);
			this.Controls.Add(this.tmatch);
			this.Controls.Add(this.lblignore);
			this.Controls.Add(this.lblmatch);
			this.Controls.Add(this.btnReplace);
			this.Controls.Add(this.btnfixdisc);
			this.Controls.Add(this.btnTrim);
			this.Controls.Add(this.lblfound);
			this.Controls.Add(this.btnMerge);
			this.Controls.Add(this.tbsecondfolder);
			this.Controls.Add(this.btnsecondfolder);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.tbfirstfolder);
			this.Controls.Add(this.btnfirstfolder);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.rtb1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.menuStrip1);
			this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "Form1";
			this.Text = "Directory Assist";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
		private System.Windows.Forms.RichTextBox rtb1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button btnfirstfolder;
		private System.Windows.Forms.TextBox tbfirstfolder;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem filesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem startFolderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem finalToolStripMenuItem;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.TextBox tbsecondfolder;
		private System.Windows.Forms.Button btnsecondfolder;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
		private System.Windows.Forms.Button btnMerge;
		private System.Windows.Forms.Label lblfound;
		private System.Windows.Forms.Button btnTrim;
		private System.Windows.Forms.Button btnfixdisc;
		private System.Windows.Forms.Button btnReplace;
		private System.Windows.Forms.Label lblmatch;
		private System.Windows.Forms.Label lblignore;
		private System.Windows.Forms.TextBox tmatch;
		private System.Windows.Forms.TextBox tignore;
		private System.Windows.Forms.TextBox tsub;
		private System.Windows.Forms.TextBox tfind;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnbraces;
		private System.Windows.Forms.Button btnemptyfolders;
	}
}

