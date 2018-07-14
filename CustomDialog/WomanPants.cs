using System;
using System.IO;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Internal;
using DotNetARX;

//别名引用，防止同时存在于两个命名空间而导致的代码冲突
using AcadApp = Autodesk.AutoCAD.ApplicationServices.Application;
using AcadWnd = Autodesk.AutoCAD.Windows;

namespace CustomDialog
{
    public partial class WomanPants : Form
    {
        public WomanPants()
        {
            InitializeComponent();
        }

        private void WomanPants_Load(object sender, EventArgs e)
        {
            panel.AutoScroll = true;//设置panel控件的自动滑动条
        }

        //廓形
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //在panel上加载廓形窗体
            FormKuoXing f = new FormKuoXing();
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            panel.Controls.Add(f);
            f.Location = new System.Drawing.Point(0, 0);
            f.Show();
        }

        //脚口
        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }

        //裤长
        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        //腰位
        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }

        //裤腰头
        private void toolStripButton5_Click(object sender, EventArgs e)
        {

        }

        //门襟与裤袢
        private void toolStripButton6_Click(object sender, EventArgs e)
        {

        }

        //前省褶
        private void toolStripButton7_Click(object sender, EventArgs e)
        {

        }

        //前口袋
        private void toolStripButton8_Click(object sender, EventArgs e)
        {

        }

        //后省褶
        private void toolStripButton9_Click(object sender, EventArgs e)
        {

        }

        //后口袋
        private void toolStripButton10_Click(object sender, EventArgs e)
        {

        }
    }
}
