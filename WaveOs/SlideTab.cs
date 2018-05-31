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
    public partial class SlideTab : UserControl
    {
        public SlideTab()
        {
            InitializeComponent();
        }
        private int _tabDefaultCount = 1;//默认tab选项卡为一个
        private int _tabCount;//当前tab选项卡的个数
        private int _tabID;//tab选项卡的id
        //private Color _tabColor;
        public List<Color> tabColors = new List<Color>();
        Color c = Color.BlueViolet;

        public int tabDefaultCount { set { _tabDefaultCount = value; } get { return _tabDefaultCount; } }
        public int tabCount { get { return _tabCount; } }
        //public Color tabColor { get { return _tabColor; } set { _tabColor = value; } }

        List<Tab> tabs = new List<Tab>();

        private void SlideTab_Load(object sender, EventArgs e)
        {
            if(tabDefaultCount>0)
            {
                tabColors.Add(c);
                Tab[] t = new Tab[tabDefaultCount];
                for (int i = 0; i < tabDefaultCount; i++)
                {
                    t[i] = new Tab();
                    t[i].tabID = i;
                    t[i].Name = "tab" + i;
                    t[i].Text = "CH" + (i + 1);
                    t[i].Location = new Point(91 * i, 0);
                    t[i].BackColor = tabColors[i];
                    this.Controls.Add(t[i]);
                    tabs.Add(t[i]);
                    _tabID++;
                }
                _tabCount = tabDefaultCount;
            }
        }
        public bool AddTab(Color c)
        {
            int i = this._tabID;
            int x = this.tabCount;
            Tab tab = new Tab();
            tab.tabID = i;
            tab.Name = "tab" + i;
            tab.Text = "CH" + (i+1);
            tab.Location = new Point(91 * x,0);
            tab.BackColor = c;
            this.Controls.Add(tab);
            tabs.Add(tab);
            _tabCount++;
            _tabID++;
            return true;
        }
        public bool RemoveTab(int id)
        {
            Control[] c = this.Controls.Find("tab"+id,false);
            this.Controls.Remove(c[0]);
            _tabCount--;
            foreach(Tab t in tabs)
            {
                if(t.Name == "tab"+id)
                {
                    tabs.Remove(t);
                    break;
                }
            }
            for(int i = id;i<tabCount;i++)
            {
                tabs[i].Location = new Point(91 * i, 0);
            }
            return true;
        }
    }

    public class Tab : Button
    {
        public int tabID;

        public Tab()
        {
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.FlatAppearance.BorderSize = 0;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Size = new System.Drawing.Size(90, 25);
            this.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        }
    }
}
