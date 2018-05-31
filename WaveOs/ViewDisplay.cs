using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Wave
{
    class ViewDisplay
    {
        public Color gridColor;//网格颜色
        public int gridSize; //网格大小
        public List<Color> waveColors; //波形颜色

        Pen pWave1, pWave2;

        public ViewDisplay(Color c,int s)
        {
            gridColor = c;
            gridSize = s;
            waveColors = new List<Color>();
            Color c1 = Color.FromArgb(255, 230, 60);
            Color c2 = Color.FromArgb(60, 230, 255);
            waveColors.Add(c1);
            waveColors.Add(c2);
            pWave1 = new Pen(waveColors[0],2);
            pWave2 = new Pen(waveColors[1]);
        }
        /// <summary>
        /// 绘制网格，显示在界面上
        /// </summary>
        /// <param name="g">画布</param>
        /// <param name="w">画布的宽度</param>
        /// <param name="h">画布的高度</param>
        /// <returns></returns>
        public bool DrawGrid(Graphics g,int w,int h)
        {
            Pen pGrid = new Pen(gridColor);
            pGrid.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            //循环画横线
            for (int i = 0;i<h/gridSize+1; i++)
            {
                g.DrawLine(pGrid, new Point(0, i*gridSize), new Point(w, i*gridSize));
            }
            //循环画竖线
            for(int i = 0;i<w/gridSize+1;i++)
            {
                g.DrawLine(pGrid, new Point(i*gridSize, 0), new Point(i*gridSize, h));
            }
            return true;
        }

        public bool DrawWave(Graphics g,float x1,float x2,float y)
        {
            g.DrawLine(pWave1, x1, y, x2, y);
            g.DrawLine(pWave1, x2, y, x2, -y);
            return true;
        }
    }

    abstract class WaveD
    {
        public Pen penWave;
        public WaveD()
        {
            Color c1 = Color.FromArgb(255, 230, 60);
            penWave = new Pen(c1, 2);
        }
        /// <summary>
        /// 制作出波形的形状方法
        /// </summary>
        /// <param name="p">传入数据点的list数组</param>
        /// <param name="g">传入画布</param>
        /// <param name="c">传入通道管理类的实例</param>
        /// <param name="id">传入通道id</param>
        /// <returns></returns>
        public abstract bool GetWave(List<PointF> p,Graphics g, ChannelManage c,int id);
    }
    class DrawSquare : WaveD
    {
        public override bool GetWave(List<PointF> p,Graphics g, ChannelManage c,int id)
        { 
            PointF[] ptNew = new PointF[p.Count];
            for (int i = 0;i < p.Count;i++)
            {
                ptNew[i].X = p[i].X * c.ChannelFold_x + c.ChannelMove_x;
                ptNew[i].Y = p[i].Y * c.Chans[id].ChannelFold_y + c.Chans[id].ChannelMove_y;
            }
            for(int i = 0;i< p.Count-1;i++)
            {
                penWave.Color = c.Chans[id].ChannelColor;
                g.DrawLine(penWave, ptNew[i], ptNew[i+1]);
            }
            return true;
        }
    }

}
