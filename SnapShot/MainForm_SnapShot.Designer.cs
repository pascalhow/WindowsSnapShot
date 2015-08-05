namespace SnapShot
{
    partial class MainForm_SnapShot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm_SnapShot));
            this.listview_ImageList = new System.Windows.Forms.ListView();
            this.pb_picturebox = new System.Windows.Forms.PictureBox();
            this.tb_FolderDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.tb_ImageDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.lbl_NumOfFiles = new System.Windows.Forms.Label();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pb_picturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // listview_ImageList
            // 
            this.listview_ImageList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listview_ImageList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listview_ImageList.Location = new System.Drawing.Point(12, 74);
            this.listview_ImageList.Name = "listview_ImageList";
            this.listview_ImageList.Size = new System.Drawing.Size(243, 453);
            this.listview_ImageList.TabIndex = 0;
            this.listview_ImageList.UseCompatibleStateImageBehavior = false;
            this.listview_ImageList.SelectedIndexChanged += new System.EventHandler(this.listview_ImageList_SelectedIndexChanged);
            this.listview_ImageList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listview_ImageList_KeyDown);
            // 
            // pb_picturebox
            // 
            this.pb_picturebox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pb_picturebox.Location = new System.Drawing.Point(274, 74);
            this.pb_picturebox.Name = "pb_picturebox";
            this.pb_picturebox.Size = new System.Drawing.Size(498, 348);
            this.pb_picturebox.TabIndex = 1;
            this.pb_picturebox.TabStop = false;
            // 
            // tb_FolderDirectory
            // 
            this.tb_FolderDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_FolderDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_FolderDirectory.Location = new System.Drawing.Point(139, 22);
            this.tb_FolderDirectory.Name = "tb_FolderDirectory";
            this.tb_FolderDirectory.Size = new System.Drawing.Size(530, 26);
            this.tb_FolderDirectory.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Folder Directory";
            // 
            // btn_Browse
            // 
            this.btn_Browse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Browse.Location = new System.Drawing.Point(675, 18);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(97, 35);
            this.btn_Browse.TabIndex = 4;
            this.btn_Browse.Text = "Browse";
            this.btn_Browse.UseVisualStyleBackColor = true;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // tb_ImageDescription
            // 
            this.tb_ImageDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_ImageDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_ImageDescription.Location = new System.Drawing.Point(274, 467);
            this.tb_ImageDescription.Multiline = true;
            this.tb_ImageDescription.Name = "tb_ImageDescription";
            this.tb_ImageDescription.Size = new System.Drawing.Size(395, 60);
            this.tb_ImageDescription.TabIndex = 5;
            this.tb_ImageDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_ImageDescription_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(270, 444);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Description";
            // 
            // btn_Edit
            // 
            this.btn_Edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Edit.Location = new System.Drawing.Point(675, 492);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(97, 35);
            this.btn_Edit.TabIndex = 7;
            this.btn_Edit.Text = "Edit";
            this.btn_Edit.UseVisualStyleBackColor = true;
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.Location = new System.Drawing.Point(675, 492);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(97, 35);
            this.btn_Save.TabIndex = 8;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // lbl_NumOfFiles
            // 
            this.lbl_NumOfFiles.AutoSize = true;
            this.lbl_NumOfFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NumOfFiles.Location = new System.Drawing.Point(13, 536);
            this.lbl_NumOfFiles.Name = "lbl_NumOfFiles";
            this.lbl_NumOfFiles.Size = new System.Drawing.Size(79, 17);
            this.lbl_NumOfFiles.TabIndex = 9;
            this.lbl_NumOfFiles.Text = "No of files: ";
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            this.fileSystemWatcher1.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Created);
            this.fileSystemWatcher1.Deleted += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Deleted);
            this.fileSystemWatcher1.Renamed += new System.IO.RenamedEventHandler(this.fileSystemWatcher1_Renamed);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // MainForm_SnapShot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.lbl_NumOfFiles);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Edit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_ImageDescription);
            this.Controls.Add(this.btn_Browse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_FolderDirectory);
            this.Controls.Add(this.pb_picturebox);
            this.Controls.Add(this.listview_ImageList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm_SnapShot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SnapShot";
            this.Load += new System.EventHandler(this.MainForm_SnapShot_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_picturebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listview_ImageList;
        private System.Windows.Forms.PictureBox pb_picturebox;
        private System.Windows.Forms.TextBox tb_FolderDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.TextBox tb_ImageDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Label lbl_NumOfFiles;
        private System.Windows.Forms.ImageList imageList;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}

