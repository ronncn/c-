using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Wave
{
    public enum ChannelType { input,output, composite ,function}
    public enum DataInterface { interface1,interface2}
    class Channel
    {
        public int ChannelID;               //通道的id
        public string ChannelName;          //通道名字
        public Color ChannelColor;          //通道的颜色
        public bool ChannelIsShow;          //通道是否显示
        public ChannelType ChannelType;     //通道的类型、输入、输出、函数、复合
        public DataInterface Interface;     //接口
        public float InterfaceValue;        //接口的数值
        public float ChannelFold_y;         //通道的倍数y
        public float ChannelMove_y;         //通道在y轴的偏移值
        
        public Channel()
        {
            ChannelIsShow = true;
            ChannelType = ChannelType.input;
            Interface = DataInterface.interface1;
            ChannelFold_y = 1.0f;
            ChannelMove_y = 0.0f;
        }
    }
    class ChannelManage
    {
        private int idd = 0;
        public int ChannelCount;        //数量
        public List<Channel> Chans;     //通道的列表数据
        public float ChannelFold_x;     //通道的倍数x
        public float ChannelMove_x;     //通道在x轴的偏移值

        public ChannelManage()
        {
            ChannelCount = 0;
            Chans = new List<Channel>();
            ChannelFold_x = 1.0f;
            ChannelMove_x = 0.0f;
        }

        public bool AddChannel(float source)
        {
            Channel ch = new Channel();
            ch.ChannelID = NewID();
            ch.ChannelName = "CH" + (ch.ChannelID + 1);
            ch.ChannelColor = RandomColor();
            ch.InterfaceValue = source;
            Chans.Add(ch);
            ChannelCount = Chans.Count;
            return true;
        }

        private int NewID()
        {
            ++idd;
            return idd-1;
        }

        public bool DelChannel(int id)
        {
            Chans.RemoveAt(id);
            ChannelCount = Chans.Count;
            return true;
        }

        /// <summary>
        /// X轴清零
        /// </summary>
        public void XClear()
        {
            this.ChannelFold_x = 1.0f;
            this.ChannelMove_x = 0.0f;
        }

        /// <summary>
        /// Y轴清零
        /// </summary>
        public void YClear(int id)
        {
            Chans[id].ChannelFold_y = 1.0f;
            Chans[id].ChannelMove_y = 0.0f;
        }

        //产生随机颜色
        Random ran = new Random();
        private Color RandomColor()
        {
            int int_Red = ran.Next(53, 169);
            int int_Green = ran.Next(53, 169);
            int int_Blue = ran.Next(53, 169);
            Color c = Color.FromArgb(255, int_Red, int_Green, int_Blue);
            return c;
        }
    }
}
