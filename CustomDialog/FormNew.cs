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
    public partial class FormNew : Form
    {
        public FormNew()
        {
            InitializeComponent();
            panel.AutoScroll = true;//设置panel控件的自动滑动条
        }

        //在panel上加载子窗体
        private void addSubForm(Form f)
        {
            panel.Controls.Clear();
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            panel.Controls.Add(f);
            f.Location = new System.Drawing.Point(0, 0);
            f.Show();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.tabControl1.SelectedIndex)
            {
                case 0:
                    FormKuoXing f1 = new FormKuoXing();
                    addSubForm(f1);
                    break;
                case 1:
                    FormFoot f2 = new FormFoot();
                    addSubForm(f2);
                    break;
                case 2:
                    FormWaistPos f3 = new FormWaistPos();
                    addSubForm(f3);
                    break;
                case 3:
                    FormZheSangF f4 = new FormZheSangF();
                    addSubForm(f4);
                    break;

            }

        }

        private void FormNew_Load(object sender, EventArgs e)
        {
            FormKuoXing f1 = new FormKuoXing();
            addSubForm(f1);
            tabControl1.SelectedIndex = 0;
        }
    }
}
