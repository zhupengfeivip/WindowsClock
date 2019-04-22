using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace WindowsClock
{
    public partial class FrmConfig : Form
    {
        public FrmConfig()
        {
            InitializeComponent();
        }

        private void FrmConfig_Load(object sender, EventArgs e)
        {
            //列举所有支持的时区列表
            var list = TimeZoneInfo.GetSystemTimeZones();
            foreach (TimeZoneInfo tzi in list)
            {
                cbxTimeZone.Items.Add(tzi);
            }

            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            int timeZoneIndex = Convert.ToInt32(cfa.AppSettings.Settings["timeZoneIndex"].Value);
            cbxTimeZone.SelectedIndex = timeZoneIndex;

            cbxRunWithSystem.Checked = Convert.ToBoolean(cfa.AppSettings.Settings["RunWithSystem"].Value);
            txtTitle.Text = cfa.AppSettings.Settings["Title"].Value;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            cfa.AppSettings.Settings["timeZoneIndex"].Value = cbxTimeZone.SelectedIndex.ToString();
            cfa.AppSettings.Settings["RunWithSystem"].Value = cbxRunWithSystem.Checked.ToString();
            cfa.AppSettings.Settings["Title"].Value = txtTitle.Text;
            cfa.Save();

            if (cbxRunWithSystem.Checked)
            {
                // 添加到 当前登陆用户的 注册表启动项
                RegistryKey runKey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                runKey.SetValue("WindowsClock", Application.ExecutablePath);
            }
            else
            {
                RegistryKey runKey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                runKey.DeleteValue("WindowsClock");
            }



            MessageBox.Show(this, "设置成功。");
            this.Close();
        }
    }
}
