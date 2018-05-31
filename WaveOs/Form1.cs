using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wave
{
    public partial class WaveOs : Form
    {
        public WaveOs()
        {
            InitializeComponent();
        }

        ChannelListItem[] ch = new ChannelListItem[4];      //初始化通道列表的数组【4】
        ChannelManage channel = new ChannelManage();        //实例化通道管理类
        SlideTab slideTab = new SlideTab();                 //实例化生成tab选项卡控件
        ViewDisplay grid = new ViewDisplay(Color.FromArgb(171, 171, 171), 100);//网格实例化 网格显示的颜色和单位像素
        DrawSquare ds = new DrawSquare();                   //实例化绘制波形类
        List<PointF> ptArray = new List<PointF>();          //定时器生成的点的数组链表
        Graphics gShow, gBuffer,gGrid;
        Bitmap bmpBuffer,bmpGrid;                           //图片 bmpBuffer缓冲图,用做在picturebox中显示波形 bmpGrid网格背景图
        int chanSID = 0;                                    //当前通道的id
        int executeCount = 0;                               //定时器执行次数
        float unitY = 100;                                  //定时器生成y值得单位
        float unitX = 50;                                   //定时器生成x值的单位
        float gridUnitX = 1;
        float gridUnitY = 1;

        //窗体加载
        private void WaveOs_Load(object sender, EventArgs e)
        {
            //tab选项卡
            slideTab.Location = new Point(9, 13);
            slideTab.tabDefaultCount = 4;
            //初始化四个通道
            for (int i = 0; i<4;i++)
            {
                channel.AddChannel(100);
                switch (i)
                {
                    case 0:
                        channel.Chans[i].ChannelType = ChannelType.input;
                        channel.Chans[i].ChannelColor = Color.FromArgb(255, 24, 206, 180);
                        break;
                    case 1:
                        channel.Chans[i].ChannelType = ChannelType.output;
                        channel.Chans[i].ChannelColor = Color.FromArgb(255, 244, 200, 49);
                        break;
                    case 2:
                        channel.Chans[i].ChannelType = ChannelType.composite;
                        channel.Chans[i].ChannelColor = Color.FromArgb(255, 255, 76, 118);
                        break;
                    case 3:
                        channel.Chans[i].ChannelType = ChannelType.function;
                        channel.Chans[i].ChannelColor = Color.FromArgb(255, 117, 94, 255);
                        break;
                }
                ch[i] = new ChannelListItem();
                ch[i].chID = channel.Chans[i].ChannelID;
                ch[i].Name = channel.Chans[i].ChannelName;
                ch[i].chColor = channel.Chans[i].ChannelColor;
                ch[i].icon = DisposeIcon(i);
                ch[i].Size = new Size(1870, 35);
                ch[i].Location = new Point(12, i * 35);
                ch[i].isShowChanged += new ChannelListItem.ChangedEventHandler(this.isShow_Changed);
                panelBottom.Controls.Add(ch[i]);
                slideTab.tabColors.Add(channel.Chans[i].ChannelColor);
            }
            panelTopRight.Controls.Add(slideTab);

            //通道面板初始化
            comboChannelType.SelectedItem = returnCombo(channel.Chans[chanSID].ChannelType);
            comboChannelInterface.SelectedItem = returnCombo(channel.Chans[chanSID].Interface);
            labDataSource.Text = Convert.ToString(channel.Chans[chanSID].InterfaceValue);
            xian0.BackColor = xian1.BackColor = xian2.BackColor = channel.Chans[chanSID].ChannelColor;
            
            //初始化显示界面网格
            gShow = pbDisplay.CreateGraphics();
            bmpBuffer = new Bitmap(pbDisplay.Width, pbDisplay.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            bmpGrid = (Bitmap)bmpBuffer.Clone();
            gBuffer = Graphics.FromImage(bmpBuffer);
            gGrid = Graphics.FromImage(bmpGrid);
            gBuffer.ResetTransform();
            gBuffer.TranslateTransform(0, 300);

            this.comboFold_x.SelectedItem = "1X";
            this.comboFold_y.SelectedItem = "1X";
        }

        private Image DisposeIcon(int id)
        {
            Image img;
            switch(channel.Chans[id].ChannelType)
            {
                case ChannelType.input:
                    img = global::WaveOs.Properties.Resources.ch1;
                    break;
                case ChannelType.output:
                    img = global::WaveOs.Properties.Resources.ch2;
                    break;
                case ChannelType.composite:
                    img = global::WaveOs.Properties.Resources.ch3;
                    break;
                case ChannelType.function:
                    img = global::WaveOs.Properties.Resources.ch4;
                    break;
                default:
                    img = global::WaveOs.Properties.Resources.ch1;
                    break;
            }
            return img;
        }

        //通道显示改变事件
        private void isShow_Changed(object sender)
        {
            ChannelListItem chan = (ChannelListItem)sender;
            if(chan.isShow)
            {
                channel.Chans[chan.chID].ChannelIsShow = true;
            }
            else
            {
                channel.Chans[chan.chID].ChannelIsShow = false;
            }
            showWave();
        }

        private void showWave()
        {
            if (channel.Chans[chanSID].ChannelIsShow)
            {
                gBuffer.Clear(Color.Transparent);
                ds.GetWave(ptArray, gBuffer, channel, chanSID);
            }
            else
            {
                gBuffer.Clear(Color.Transparent);
            }
            pbDisplay.Image = bmpBuffer;
        }

        private string returnCombo(ChannelType n)
        {
            string ChanType;
            switch(n)
            {
                case ChannelType.input:
                    ChanType = "输入";
                    break;
                case ChannelType.output:
                    ChanType = "输出";
                    break;
                case ChannelType.composite:
                    ChanType = "复合";
                    break;
                case ChannelType.function:
                    ChanType = "函数";
                    break;
                default:
                    ChanType = "输入";
                    break;
            }
            return ChanType;
        }

        private void comboChannelType_SelectedValueChanged(object sender, EventArgs e)
        {
            switch(comboChannelType.SelectedItem)
            {
                case "输入":
                    ch[0].icon = global::WaveOs.Properties.Resources.ch1;
                    break;
                case "输出":
                    ch[0].icon = global::WaveOs.Properties.Resources.ch2;
                    break;
                case "复合":
                    ch[0].icon = global::WaveOs.Properties.Resources.ch3;
                    break;
                case "函数":
                    ch[0].icon = global::WaveOs.Properties.Resources.ch4;
                    break;
                default:
                    ch[0].icon = global::WaveOs.Properties.Resources.ch1;
                    break;
            }
        }

        private string returnCombo(DataInterface n)
        {
            string intf;
            switch(n)
            {
                case DataInterface.interface1:
                    intf = "接口1";
                    break;
                case DataInterface.interface2:
                    intf = "接口2";
                    break;
                default:
                    intf = "接口1";
                    break;
            }
            return intf;
        }

        //添加通道按钮
        private void button2_Click(object sender, EventArgs e)
        {
            //添加通道
            channel.AddChannel(100);
            ChannelListItem chan = new ChannelListItem();
            int chanCount = 0;
            foreach (Control c in panelBottom.Controls)
            {
                if (c is ChannelListItem)
                {
                    chanCount++;
                }
            }
            chan.Name = channel.Chans[chanCount].ChannelName;
            chan.chColor = channel.Chans[chanCount].ChannelColor;
            chan.Location = new Point(12, 140);
            panelBottom.Controls.Add(chan);
            panelBottom.VerticalScroll.Value = panelBottom.VerticalScroll.Maximum;

            //添加选项卡
            slideTab.AddTab(channel.Chans[chanCount].ChannelColor);
        }

        //水平滚动条
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            float fv = (45 - hScrollBar1.Value) * 10;
            channel.ChannelMove_x = -fv;
            labelChannelOffset_x.Text = Convert.ToString(channel.ChannelMove_x * gridUnitX * channel.ChannelFold_x) + "ms";
            showWave();
        }

        //垂直滚动条
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            float fv = (vScrollBar1.Value - 45) * 10;
            channel.Chans[chanSID].ChannelMove_y = fv;
            labelChannelOffset_y.Text = Convert.ToString(-channel.Chans[chanSID].ChannelMove_y * gridUnitY * channel.Chans[chanSID].ChannelFold_y)+ "mv";
            showWave();
        }
        
        private void comboFold_x_SelectedIndexChanged(object sender, EventArgs e)
        {
            float foldXValue = float.Parse(Convert.ToString(comboFold_x.SelectedItem).Replace("X", null));
            channel.ChannelFold_x = foldXValue;
            labelUnitX.Text = Convert.ToString("T="+ gridUnitX * foldXValue * 100 + "ms");
            labelChannelOffset_x.Text = Convert.ToString(channel.ChannelMove_x * gridUnitX * channel.ChannelFold_x) + "ms";
            showWave();
        }

        private void comboFold_y_SelectedIndexChanged(object sender, EventArgs e)
        {
            float foldYValue = float.Parse(Convert.ToString(comboFold_y.SelectedItem).Replace("X", null));
            channel.Chans[chanSID].ChannelFold_y = foldYValue;
            labelChannelOffset_y.Text = Convert.ToString(channel.Chans[chanSID].ChannelMove_y * gridUnitY * channel.Chans[chanSID].ChannelFold_y);
            showWave();
        }

        //清除偏移值——X
        private void btnClearChannelMove_x_Click(object sender, EventArgs e)
        {
            channel.XClear();
            labelChannelOffset_x.Text = "0ms";
            hScrollBar1.Value = 45;
            showWave();
        }

        //清除偏移值——Y
        private void btnClearChannelMove_y_Click(object sender, EventArgs e)
        {
            channel.YClear(chanSID);
            labelChannelOffset_y.Text = "0mv";
            vScrollBar1.Value = 45;
            showWave();
        }

        //计时器，生成点的数组
        private void timer1_Tick(object sender, EventArgs e)
        {
            gShow.ResetTransform();
            gShow.TranslateTransform(0, 300);
            //暂时的一个设定100次 10s
            if (executeCount<100)
            {
                float f1 = unitX * executeCount;
                float f2 = unitX * (executeCount + 1);
                PointF pt1 = new PointF(f1, unitY);
                PointF pt2 = new PointF(f2, unitY);
                ptArray.Add(pt1);
                ptArray.Add(pt2);
                executeCount++;
                unitY = -unitY;
                showWave();
            }
            else
            {
                timer1.Enabled = false;
            }
        }

        private void pbDisplay_Paint(object sender, PaintEventArgs e)
        {
            //绘制网格,每格60像素
            grid.DrawGrid(gGrid, pbDisplay.Width, pbDisplay.Height);
            pbDisplay.BackgroundImage = bmpGrid;
        }

    }
}
