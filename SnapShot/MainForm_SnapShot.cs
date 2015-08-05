using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Windows.Media.Imaging;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace SnapShot
{
    public partial class MainForm_SnapShot : Form
    {
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);


        private const int WM_DRAWCLIPBOARD = 0x0308;    // WM_DRAWCLIPBOARD message
        private IntPtr _clipboardViewerNext;    // Our variable to hold the value to identify the next window in the clipboard viewer chain 

        //  Create a list to contain images class: name and path
        List<Captured_Images> m_captured_image_list = new List<Captured_Images>();

        public MainForm_SnapShot()
        {
            InitializeComponent();
        }

        private void MainForm_SnapShot_Load(object sender, EventArgs e)
        {
            lbl_NumOfFiles.Text = "0 Files";
            Clipboard.Clear();  //  Make sure there are no left over images on clipboard on startup
            
            //  Get the system's desktop path to save captured images
            //  We choose desktop for simplicity and all Windows versions have a desktop
            string directory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Screen Capture Photos";
            
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            tb_FolderDirectory.Text = directory;
            tb_ImageDescription.Enabled = false;        //   Disable textbox for image descriptions
            btn_Save.Visible = false;                   //   Ok button disappears
            btn_Edit.Visible = true;                    //   Update button becomes visible again 

            fileSystemWatcher1.Path = tb_FolderDirectory.Text;

            //  Populate our image list view on start up
            Update_ImageList(directory);

            // Adds our form to the chain of clipboard viewers.
            _clipboardViewerNext = SetClipboardViewer(this.Handle);
        }

        private void MainForm_ScreenCapture_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Removes our form from the chain of clipboard viewers when the form closes
            ChangeClipboardChain(this.Handle, _clipboardViewerNext);
        }

        private void listview_ImageList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listview_ImageList.FocusedItem.Index >= 0)
            {
                //  Get image location for display
                pb_picturebox.ImageLocation = m_captured_image_list[listview_ImageList.FocusedItem.Index].image_path;

                //  Set size mode so that image fits within picturebox
                pb_picturebox.SizeMode = PictureBoxSizeMode.Zoom;

                //  Display the existing comment from image Metadata
                JpegMetadataAdapter jpeg = new JpegMetadataAdapter(pb_picturebox.ImageLocation);
                tb_ImageDescription.Text = jpeg.Metadata.Comment;
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);    // Process the message 

            if ((m.Msg == WM_DRAWCLIPBOARD) && (tb_FolderDirectory.Text != string.Empty))
            {
                IDataObject iData = Clipboard.GetDataObject();      // Clipboard's data

                if (iData.GetDataPresent(DataFormats.Bitmap))
                {
                    Bitmap image = (Bitmap)iData.GetData(DataFormats.Bitmap);   // Get clipboard image

                    Form_ImageDescription form_imagedescription = new Form_ImageDescription();
                    form_imagedescription.TopMost = true;                   //  Set form priority before showing it so it stays topmost
                    form_imagedescription.imageproperties.image = image;    //  Pass image to child form
                    
                    form_imagedescription.ShowDialog();

                    //  Only save comment and captured image if user clicked ok in ImageDescription form
                    if (form_imagedescription.imageproperties.imagesaved == true)
                    {
                        ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);
                        System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;

                        EncoderParameters myEncoderParameters = new EncoderParameters(1);

                        EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 100L);
                        myEncoderParameters.Param[0] = myEncoderParameter;

                        //  Name image according to current time in .jpg format
                        string current_time = DateTime.Now.ToString("yyyyMMddHHmmss");
                        image.Save(tb_FolderDirectory.Text + "\\" + current_time + ".jpg", jgpEncoder, myEncoderParameters);

                        //  Add the comment and save 
                        JpegMetadataAdapter jpeg = new JpegMetadataAdapter(tb_FolderDirectory.Text + "\\" + current_time + ".jpg");
                        jpeg.Metadata.Comment = form_imagedescription.imageproperties.comment;
                        jpeg.Save();
                    }
                }
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (pb_picturebox.Image != null)
            {
                //  Save new comments, restore button visibility and disable Imagedescription box
                JpegMetadataAdapter jpeg = new JpegMetadataAdapter(pb_picturebox.ImageLocation);
                jpeg.Metadata.Comment = tb_ImageDescription.Text;
                jpeg.Save();

                btn_Edit.Visible = true;
                btn_Save.Visible = false;
                tb_ImageDescription.Enabled = false;
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (pb_picturebox.Image != null)
            {
                //  Update button disappears and gives way to Save button
                tb_ImageDescription.Enabled = true;
                btn_Edit.Visible = false;
                btn_Save.Visible = true;
            }
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {         
            tb_ImageDescription.Text = string.Empty;    //   Clear text box
            tb_ImageDescription.Enabled = false;        //   Disable textbox for image descriptions
            btn_Save.Visible = false;                   //   Ok button disappears
            btn_Edit.Visible = true;                    //   Update button becomes visible again 
                 
            //  Open folder dialog to select folder
            FolderBrowserDialog folderbrowserdialog = new FolderBrowserDialog();
            DialogResult result = folderbrowserdialog.ShowDialog();

            //  If user clicked OK
            if (result == DialogResult.OK)
            {
                string directory = folderbrowserdialog.SelectedPath;
                
                //  Display folder directory in text box
                tb_FolderDirectory.Text = folderbrowserdialog.SelectedPath;
                fileSystemWatcher1.Path = tb_FolderDirectory.Text;

                try
                {
                    Update_ImageList(directory);
                }
                catch (Exception exception)
                {
                    //  Errors may occur if user modifies a selected folder while choosing a folder from folder browser dialog
                    MessageBox.Show(exception.ToString());
                }
            } 
        }

        private void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
        {
            string directory = tb_FolderDirectory.Text;

            //  MessageBox.Show(string.Format("Created: {0} {1}", e.FullPath, e.ChangeType));
            Update_ImageList(directory);
        }

        private void fileSystemWatcher1_Deleted(object sender, FileSystemEventArgs e)
        {
            string directory = tb_FolderDirectory.Text;

            //  MessageBox.Show(string.Format("Deleted: {0} {1}", e.FullPath, e.ChangeType));
            Update_ImageList(directory);
        }

        private void fileSystemWatcher1_Renamed(object sender, RenamedEventArgs e)
        {
            string directory = tb_FolderDirectory.Text;

            //  MessageBox.Show(string.Format("Renamed: {0} {1}", e.FullPath, e.ChangeType));
            Update_ImageList(directory);
        }

        private void Update_ImageList(string directory)
        {
            listview_ImageList.Items.Clear();           //  Clear Image list 
            string[] array = { };                       //  Clear our array of image complete paths
            m_captured_image_list.Clear();              //  Clear our list of image class
            pb_picturebox.Image = null;                 //  Clear picturebox
            imageList.Images.Clear();                   //  Clear imageList
            pb_picturebox.ImageLocation = string.Empty; //  Clear images path associated with picturebox
            
            //  search for all JPGs in top directory only
            array = Directory.GetFiles(directory, "*.jpg", SearchOption.TopDirectoryOnly).Select(x => Path.GetFullPath(x)).ToArray();

            listview_ImageList.View = View.SmallIcon;
            imageList.ImageSize = new Size(40, 40);
            listview_ImageList.SmallImageList = imageList;

            //  Wrap for loop between BeginUpdate and EndUpdate to only update graphic once list view is filled
            listview_ImageList.BeginUpdate();

            this.Cursor = Cursors.WaitCursor;
            
            for (int i = 0; i < array.Length; i++)
            {
                //  Instantiate each element of the Captured_Images class
                Captured_Images captured_images = new Captured_Images();

                //  Save the name and path of each image class object
                captured_images.image_name = array[i].Substring((directory.Length) + 1, array[i].Length - directory.Length - 1);
                captured_images.image_path = array[i];

                //  Add each captured_image class object to the Image list and populate listbox
                m_captured_image_list.Add(captured_images);

                //  Use Image.FromStream instead of Image.FromFile as it allows image.Dispose()
                using (FileStream stream = new FileStream(captured_images.image_path, FileMode.Open, FileAccess.Read))
                {
                    Image originalimage = Image.FromStream(stream);

                    Image imagethumbnail = originalimage.GetThumbnailImage(45, 45, null, IntPtr.Zero);
                    imageList.Images.Add(imagethumbnail);
                    imagethumbnail.Dispose();
                    originalimage.Dispose();
                }

                ListViewItem item = new ListViewItem(m_captured_image_list[i].image_name);
                item.ImageIndex = i;
                listview_ImageList.Items.Add(item);
            }       

            listview_ImageList.EndUpdate();

            //  Update number of file count label
            lbl_NumOfFiles.Text = listview_ImageList.Items.Count.ToString() + " Files";

            this.Cursor = Cursors.Default;
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        private void tb_ImageDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (pb_picturebox.Image != null)
                {
                    //  Save new comments, restore button visibility and disable Imagedescription box
                    JpegMetadataAdapter jpeg = new JpegMetadataAdapter(pb_picturebox.ImageLocation);
                    jpeg.Metadata.Comment = tb_ImageDescription.Text;
                    jpeg.Save();

                    btn_Edit.Visible = true;
                    btn_Save.Visible = false;
                    tb_ImageDescription.Enabled = false;
                }
            }
        }

        private void listview_ImageList_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Delete) && (listview_ImageList.Items.Count > 0) && (listview_ImageList.FocusedItem != null))
            {
                //  Delete selected item from list view and from folder and delete comment from image textbox description
                string filepath = m_captured_image_list[listview_ImageList.FocusedItem.Index].image_path;
                listview_ImageList.Items.Remove(listview_ImageList.FocusedItem);
                File.Delete(filepath);
                tb_ImageDescription.Text = string.Empty;
            }
        }
    }
}