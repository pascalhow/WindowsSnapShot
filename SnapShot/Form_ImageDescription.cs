using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SnapShot
{
    public partial class Form_ImageDescription : Form
    {
        private ImageProperties _imgProperty = new ImageProperties();

        public Form_ImageDescription()
        {
            InitializeComponent();
        }

        private void Form_ImageDescription_Load(object sender, EventArgs e)
        {
            pb_Screenshot.Image = _imgProperty.image;
            pb_Screenshot.SizeMode = PictureBoxSizeMode.Zoom;   //  Set size mode so that image fits within picturebox
            pb_Screenshot.Update();
        }

        public ImageProperties imageproperties
        {
            get { return (_imgProperty); }
            set { _imgProperty = value; }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            //  Save user comments and close form
            _imgProperty.comment = tb_UserComments.Text;
            _imgProperty.imagesaved = true;

            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            //  Do not approve image and close the form
            _imgProperty.imagesaved = false;
            this.Close();
        }

        private void tb_UserComments_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //  Save user comments and close form
                _imgProperty.comment = tb_UserComments.Text;
                _imgProperty.imagesaved = true;
                this.Close();
            }
            
            else if (e.KeyCode == Keys.Escape)
            {
                //  Do not approve image and close the form
                _imgProperty.imagesaved = false;
                this.Close();
            }
        }
    }
}
