using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace addlables
{

    public partial class Form1 : Form
    {
        static int i = 0;
        static clsMCI cm;


        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           
            Random rd = new Random();
            int i2 = rd.Next();
            string at = i2.ToString();
           Label lbl = new Label();//声明一个label
         //   lbl.Location = new System.Drawing.Point(0, i);//设置位置
            
            //    lbl.Size = new Size(20, 30);//设置大小
            lbl.Text = at;//设置Text值
            lbl.Name = "label3";
            

            int ch=0, cy=0;
            Control.ControlCollection sonControls = this.pan .Controls;
            //遍历所有控件
            foreach (Control control in sonControls)
            {
                //  listBox1.Items.Add(control.Name);

                cy=control.Location.Y;
                
                ch=control.Size.Height;
            }

            lbl.Location = new Point(0,cy+ch+10);
            pan.Controls.Add(lbl);
            lbl.Focus();
     //       int hua = pan.VerticalScroll.Maximum;
         //   Console.WriteLine(hua);
           //     pan.VerticalScroll.LargeChange = hua;
         //   pan.Controls..Add(lbl);//在当前窗体上添加这个label控件
          //  Point location = label90.Location;
          //  Console.WriteLine(location);
        
        }
        private void GetControls1(Control fatherControl)
        {
            Control.ControlCollection sonControls = fatherControl.Controls;
            //遍历所有控件
            foreach (Control control in sonControls)
            {
              //  listBox1.Items.Add(control.Name);
                
                Console.WriteLine(control.Location);
                Console.WriteLine(control.Name);
                Console.WriteLine(control.Size);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetControls1(this.pan);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random rd = new Random();
            int i2 = rd.Next();
            string at = i2.ToString();
            
            this.listView1.View = View.List;
            listView1.Items.Add(at);
            Label lbl = new Label();
            lbl.Name = "label3";
            lbl.Text = at;

            listBox1.Items.Add(lbl.Text);
            Label lb1 = new Label();//声明一个label
                                    //   lbl.Location = new System.Drawing.Point(0, i);//设置位置

            //    lbl.Size = new Size(20, 30);//设置大小
            lbl.Text = "helloworld111111111111";//设置Text值
            lbl.Name = "label3";
            int h = lbl.Size.Height;
            lbl.Location = new Point(0, 0);
            pan.Controls.Add(lbl);






        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            
            Random rd = new Random();
            int i2 = rd.Next();
            string at = i2.ToString();
            Label lbl = new Label();
            //声明一个label
            //   lbl.Location = new System.Drawing.Point(0, i);//设置位置

            //    lbl.Size = new Size(20, 30);//设置大小
            lbl.Text = at;//设置Text值
            lbl.Name = "label3";
            lbl.BorderStyle = BorderStyle.FixedSingle;


            int ch = 0, cy = 0;
            Control.ControlCollection sonControls = this.pan.Controls;
            //遍历所有控件
            foreach (Control control in sonControls)
            {
                //  listBox1.Items.Add(control.Name);

                cy = control.Location.Y;

                ch = control.Size.Height;
            }

            lbl.Location = new Point(0, cy + ch + 10);
            pan.Controls.Add(lbl);
            lbl.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"b2a.jpg");
            
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void button6_Click(object sender, EventArgs e)
        {

            clsMCI cm = new clsMCI();
           if (i == 0)
            { 
                cm.FileName = @"C:\Users\dell\Desktop\3908406844.mp3";
                cm.play();
                 i = 2;


            }
            else if(i==2)
            {
                cm.Puase();
                i = 3;           
                    }
            else
            {
                cm.play();
            }
                    
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            clsMCI cm = new clsMCI();
            cm.Puase();
            
        }
    }
    public class clsMCI
    {
        public clsMCI()
        {
        }
        //定义API函数使用的字符串变量 
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        private string Name = "";
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        private string durLength = "";
        [MarshalAs(UnmanagedType.LPTStr, SizeConst = 128)]
        private string TemStr = "";
        int ilong;
        //定义播放状态枚举变量
        public enum State
        {
            mPlaying = 1,
            mPuase = 2,
            mStop = 3
        };
        //结构变量
        public struct structMCI
        {
            public bool bMut;
            public int iDur;
            public int iPos;
            public int iVol;
            public int iBal;
            public string iName;
            public State state;
        };
        public structMCI mc = new structMCI();
        //取得播放文件属性
        public string FileName
        {
            get
            {
                return mc.iName;
            }
            set
            {
                try
                {
                    TemStr = "";
                    TemStr = TemStr.PadLeft(127, Convert.ToChar(" "));
                    Name = Name.PadLeft(260, Convert.ToChar(" "));
                    mc.iName = value;
                    ilong = APIClass.GetShortPathName(mc.iName, Name, Name.Length);
                    Name = GetCurrPath(Name);
                    Name = "open " + Convert.ToChar(34) + Name + Convert.ToChar(34) + " alias media";
                    ilong = APIClass.mciSendString("close all", TemStr, TemStr.Length, 0);
                    ilong = APIClass.mciSendString(Name, TemStr, TemStr.Length, 0);
                    ilong = APIClass.mciSendString("set media time format milliseconds", TemStr, TemStr.Length, 0);
                    mc.state = State.mStop;
                }
                catch
                {
                }
            }
        }
        //播放
        public void play()
        {
            TemStr = "";
            TemStr = TemStr.PadLeft(127, Convert.ToChar(" "));
            APIClass.mciSendString("play media", TemStr, TemStr.Length, 0);
            mc.state = State.mPlaying;
        }
        //停止
        public void StopT()
        {
            TemStr = "";
            TemStr = TemStr.PadLeft(128, Convert.ToChar(" "));
            ilong = APIClass.mciSendString("close media", TemStr, 128, 0);
            ilong = APIClass.mciSendString("close all", TemStr, 128, 0);
            mc.state = State.mStop;
        }
        public void Puase()
        {
            TemStr = "";
            TemStr = TemStr.PadLeft(128, Convert.ToChar(" "));
            ilong = APIClass.mciSendString("pause media", TemStr, TemStr.Length, 0);
            mc.state = State.mPuase;
        }
        private string GetCurrPath(string name)
        {
            if (name.Length < 1) return "";
            name = name.Trim();
            name = name.Substring(0, name.Length - 1);
            return name;
        }
        //总时间
        public int Duration
        {
            get
            {
                durLength = "";
                durLength = durLength.PadLeft(128, Convert.ToChar(" "));
                APIClass.mciSendString("status media length", durLength, durLength.Length, 0);
                durLength = durLength.Trim();
                if (durLength == "") return 0;
                return (int)(Convert.ToDouble(durLength) / 1000f);
            }
        }
        //当前时间
        public int CurrentPosition
        {
            get
            {
                durLength = "";
                durLength = durLength.PadLeft(128, Convert.ToChar(" "));
                APIClass.mciSendString("status media position", durLength, durLength.Length, 0);
                mc.iPos = (int)(Convert.ToDouble(durLength) / 1000f);
                return mc.iPos;
            }
        }
    }
    public class APIClass
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetShortPathName(
         string lpszLongPath,
         string shortFile,
         int cchBuffer
      );
        [DllImport("winmm.dll", EntryPoint = "mciSendString", CharSet = CharSet.Auto)]
        public static extern int mciSendString(
           string lpstrCommand,
           string lpstrReturnString,
           int uReturnLength,
           int hwndCallback
          );
    }
}
