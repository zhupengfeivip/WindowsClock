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

        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;
        Rectangle rect = System.Windows.Forms.SystemInformation.VirtualScreen;
        internal AnchorStyles StopAanhor = AnchorStyles.None;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    if ((int)m.Result == HTCLIENT)
                        m.Result = (IntPtr)HTCAPTION;
                    return;
                    break;
            }
            base.WndProc(ref m);
        }

        private void mStopAnhor()
        {
            if (this.Top <= 0)
            {
                StopAanhor = AnchorStyles.Top;
            }
            else if (this.Left <= 0)
            {
                StopAanhor = AnchorStyles.Left;
            }
            else if (this.Left >= Screen.PrimaryScreen.Bounds.Width - this.Width)
            {
                StopAanhor = AnchorStyles.Right;
            }
            else
            {
                StopAanhor = AnchorStyles.None;
            }
        }

        private void HideForm()
        {
            if (this.Bounds.Contains(Cursor.Position))
            {
                switch (this.StopAanhor)
                {
                    case AnchorStyles.Top:
                        //窗体在最上方隐藏时，鼠标接触自动出现
                        this.Location = new Point(this.Location.X, 0);
                        break;
                    //窗体在最左方隐藏时，鼠标接触自动出现
                    case AnchorStyles.Left:
                        this.Location = new Point(0, this.Location.Y);
                        break;
                    //窗体在最右方隐藏时，鼠标接触自动出现
                    case AnchorStyles.Right:
                        this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - this.Width, this.Location.Y);
                        break;
                }
            }
            else
            {
                //窗体隐藏时在靠近边界的一侧边会出现2像素原因：感应鼠标，同时2像素不会影响用户视线
                switch (this.StopAanhor)
                {
                    //窗体在顶部时时，隐藏在顶部，底部边界出现2像素
                    case AnchorStyles.Top:
                        this.Location = new Point(this.Location.X, (this.Height - 2) * (-1));
                        break;
                    //窗体在最左边时时，隐藏在左边，右边边界出现2像素
                    case AnchorStyles.Left:
                        this.Location = new Point((-1) * (this.Width - 2), this.Location.Y);
                        break;
                    //窗体在最右边时时，隐藏在右边，左边边界出现2像素
                    case AnchorStyles.Right:
                        this.Location = new Point(Screen.PrimaryScreen.Bounds.Width - 2, this.Location.Y);
                        break;
                }
            }
        }



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
            //转换为目标时区时间
            DateTime dt4 = TimeZoneInfo.ConvertTimeFromUtc(dt, TimeZoneInfo.FindSystemTimeZoneById(list[timeZoneIndex].Id));
            if (timeZoneIndex == 103)
                dt4 = DateTime.Now; //北京时间直接取本地时间
            string[] day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
            string week = day[Convert.ToInt32(dt4.DayOfWeek.ToString("d"))].ToString();
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
            this.lblTitle.Text = cfa.AppSettings.Settings["Title"].Value;

            this.TopMost = true;
            timer1.Interval = 100;
            timer1.Start();
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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

        private void FrmMain_LocationChanged(object sender, EventArgs e)
        {
            mStopAnhor();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            HideForm();
        }
    }
}
