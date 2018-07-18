using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomDialog
{
    public partial class FormFoot : Form
    {
        public FormFoot()
        {
            InitializeComponent();
        }

        private System.Drawing.Bitmap GetResourceBitmap(string strImageName)
        {
            object obj = Properties.Resources.ResourceManager.GetObject(strImageName, Properties.Resources.Culture);
            return ((System.Drawing.Bitmap)(obj));
        }

        private System.Drawing.Image GetResourceImage(string strImageName)
        {
            object obj = Properties.Resources.ResourceManager.GetObject(strImageName, Properties.Resources.Culture);
            return ((System.Drawing.Image)(obj));
        }

        private void changeL(string name)
        {
            pictureBox1.Image = GetResourceImage(name);
            label1.Text = name;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            int i = e.NewValue / 10;
            if(i<4)
            {
                if(i<2)
                {
                    if (i < 1)
                        changeL("超短裤");
                    else
                        changeL("牙买加短裤");
                }
                else
                {
                    if (i < 3)
                        changeL("百慕大短裤");
                    else
                        changeL("五分裤");
                }
            }
            else
            {
                if (i < 6)
                {
                    if (i < 5)
                        changeL("七分裤");
                    else
                        changeL("八分裤");
                }
                else
                {
                    if (i < 7)
                        changeL("九分裤");
                    else
                        changeL("长裤");
                }
            }
        }
    }
}
