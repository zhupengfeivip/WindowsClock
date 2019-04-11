using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsClock
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);



        bool beginMove = false;//初始化鼠标位置
        int currentXPosition;
        int currentYPosition;


        private void FrmMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //获取鼠标按下时的位置
                beginMove = true;
                currentXPosition = MousePosition.X; //鼠标的x坐标为当前窗体左上角x坐标
                currentYPosition = MousePosition.Y; //鼠标的y坐标为当前窗体左上角y坐标
            }
        }

        private void FrmMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (beginMove)
            {
                this.Left += MousePosition.X - currentXPosition; //根据鼠标x坐标确定窗体的左边坐标x
                this.Top += MousePosition.Y - currentYPosition; //根据鼠标的y坐标窗体的顶部，即Y坐标
                currentXPosition = MousePosition.X;
                currentYPosition = MousePosition.Y;
            }
        }

        private void FrmMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                currentXPosition = 0; //设置初始状态
                currentYPosition = 0;
                beginMove = false;

                SaveLastLocation();
            }
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            //UTC 时间
            DateTime dt = TimeZoneInfo.ConvertTimeToUtc(DateTime.Now, TimeZoneInfo.Local);
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            int timeZoneIndex = Convert.ToInt32(cfa.AppSettings.Settings["timeZoneIndex"].Value);
            //列举所有支持的时区列表
            var list = TimeZoneInfo.GetSystemTimeZones();
            DateTime dt4 = TimeZoneInfo.ConvertTimeFromUtc(dt, TimeZoneInfo.FindSystemTimeZoneById(list[timeZoneIndex].Id));
            string[] Day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            string week = Day[Convert.ToInt32(DateTime.Now.DayOfWeek.ToString("d"))].ToString();
            lblDay.Text = dt4.ToString("yyyy-MM-dd") + " " + week;
            lblTime.Text = dt4.ToString("HH:mm");
        }

        private void tsmiConfig_Click(object sender, EventArgs e)
        {
            FrmConfig frm = new FrmConfig();
            frm.ShowDialog(this);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            int x = Convert.ToInt32(cfa.AppSettings.Settings["LastLocationX"].Value);
            int y = Convert.ToInt32(cfa.AppSettings.Settings["LastLocationY"].Value);
            this.Location = new Point(x, y);
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        /// <summary>
        /// 保存最后位置
        /// </summary>
        private void SaveLastLocation()
        {
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            cfa.AppSettings.Settings["LastLocationX"].Value = Location.X.ToString();
            cfa.AppSettings.Settings["LastLocationY"].Value = Location.Y.ToString();
            cfa.Save();
        }

        private void tsmiClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
