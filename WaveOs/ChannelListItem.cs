using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wave
{
    public partial class ChannelListItem : UserControl
    {
        public ChannelListItem()
        {
            InitializeComponent();
            chColor = Color.FromArgb(28,207,181);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            foreach(Control c in this.Controls)
            {
                c.Click += new System.EventHandler(this.Focus_Click);
            }
        }

        private int _chID;
        private Color _chColor;
        private bool _isFocus = false;
        private bool _isShow = true;
        private Image _icon = global::WaveOs.Properties.Resources.ch1;

        public delegate void ChangedEventHandler(object sender);//定义委托
        public event ChangedEventHandler isShowChanged;//定义事件

        //public delegate void ChangedHandeler();
        //public event ChangedHandeler iconChanged;
        public int chID {  get { return _chID; } set { _chID = value; } }
        public Color chColor { set { _chColor = value; } get { return _chColor; } }
        public bool isFocus { set{ if (_isFocus != value) { _isFocus = value; OnChanged(); } } get { return _isFocus; } }
        public bool isShow { get { return _isShow; } set { if (_isShow != value) { _isShow = value; isShowChanged(this); } } }
        public Image icon { get { return _icon; }set { if (_icon != value) { _icon = value; iconChanged(); } } }

        protected void OnChanged()
        {
            if(isFocus)
            {
                initialChanelPaint();
                Graphics g = this.CreateGraphics();
                Pen penFocus = new Pen(chColor, 4);
                g.DrawLine(penFocus, 120, 0, 1870, 0);
                g.DrawLine(penFocus, 120, 35, 1870, 35);
                g.DrawLine(penFocus, 1870, 0, 1870, 35);
                g.Dispose();
                penFocus.Dispose();
            }
            else
            {
                initialChanelPaint();
            }
        }
        protected void iconChanged()
        {
            pictureBox2.BackgroundImage = icon;
            labChannelTitle.Text = "123";
        }

        private void Focus_Click(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void btnChannelShow_Click(object sender, EventArgs e)
        {
            isShow = !isShow;
            isShowMark();
        }
        
        private void isShowMark()
        {
            if (isShow)
            {
                this.btnChannelShow.BackgroundImage = global::WaveOs.Properties.Resources.show;
            }
            else
            {
                this.btnChannelShow.BackgroundImage = global::WaveOs.Properties.Resources.none;
            }
        }

        private void ChannelListItem_Paint(object sender, PaintEventArgs e)
        {
            isShowMark();
            labChannelTitle.Text = Name;
            if(isFocus)
            {
                initialChanelPaint();
                Graphics g = this.CreateGraphics();
                Pen penFocus = new Pen(chColor, 4);
                g.DrawLine(penFocus, 120, 0, 1870, 0);
                g.DrawLine(penFocus, 120, 35, 1870, 35);
                g.DrawLine(penFocus, 1870, 0, 1870, 35);
                g.Dispose();
                penFocus.Dispose();
            }
            else
            {
                initialChanelPaint();
            }
        }

        private void initialChanelPaint()
        {
            Graphics g = this.CreateGraphics();
            Bitmap bmpBuffer = new Bitmap(this.Width, this.Height);
            Graphics gBuffer = Graphics.FromImage(bmpBuffer);
            Brush brushBg = new SolidBrush(chColor);
            Brush brushFg = new SolidBrush(Color.FromArgb(150, 255, 255, 255));
            gBuffer.FillRectangle(brushBg, 100, 0, 1770, 35);
            gBuffer.FillRectangle(brushFg, 120, 0, 1750, 35);
            g.DrawImage(bmpBuffer, 0, 0);
            Color color = bmpBuffer.GetPixel(120, 1);
            pictureBox2.BackColor = color;
            btnChannelDel.BackColor = color;
            g.Dispose();
            gBuffer.Dispose();
            bmpBuffer.Dispose();
            brushBg.Dispose();
            brushFg.Dispose();
        }

        private void ChannelListItem_Enter(object sender, EventArgs e)
        {
            isFocus = true;
        }

        private void ChannelListItem_Leave(object sender, EventArgs e)
        {
            isFocus = false;
        }

        private void btnChannelDel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定删除?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if(dr == DialogResult.OK)
            {
                //删除代码
            }
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            pictureBox2.BackgroundImage = icon;
        }
    }
}
