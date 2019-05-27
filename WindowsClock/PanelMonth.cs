using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsClock
{
    public partial class PanelMonth : UserControl
    {
        public PanelMonth()
        {
            InitializeComponent();
            DisplayPD(datetime);
        }

        private DateTime datetime = System.DateTime.Now;

        public DateTime Datetime
        {
            get { return datetime; }
            set
            {
                datetime = value;
                dateTimePicker.Value = datetime;
            }
        }

        public void Add(PanelDay pd, int x, int y)
        {
            pd.Location = new System.Drawing.Point(x * 56, y * 62);
            panelWall.Controls.Add(pd);
        }

        public void Add(PanelDay pd)
        {
            panelWall.Controls.Add(pd);
        }

        public void DisplayPD(DateTime datetime)
        {
            panelWall.Controls.Clear();
            DateTimeDS dt = new DateTimeDS();
            int dim = dt.daysInMonth(dateTimePicker.Value.Year, dateTimePicker.Value.Month);
            PanelDay[] panelday = new PanelDay[dim];
            for (int d = 0; d < dim; d++)
            {
                panelday[d] = new PanelDay();
                panelday[d].Name = "pd" + (d + 1).ToString();
                panelday[d].Solar = (d + 1).ToString();
                panelday[d].Lunar = dt.getLunarDay(dateTimePicker.Value.Year, dateTimePicker.Value.Month, d + 1);
                panelday[d].MouseEnter += new EventHandler(PanelMonth_MouseEnter);
                panelday[d].MouseLeave += new EventHandler(PanelMonth_MouseLeave);
                panelday[d].MouseClick += PanelMonth_MouseClick;
                panelday[d].Terms = dt.terms(new DateTime(dateTimePicker.Value.Year, dateTimePicker.Value.Month, d + 1));
                if (datetime.Day == d + 1)
                {
                    panelday[d].BackColor = Color.Green;
                }
            }
            int index = 0;
            DateTime newtime = dateTimePicker.Value;
            DateTime firstdaytime = new DateTime(newtime.Year, newtime.Month, 1);
            int firstday = (int)firstdaytime.DayOfWeek;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {

                    if (i == 0 && j < firstday) { }
                    else if (index < dim)
                    {
                        Add(panelday[index], j, i);
                        index++;
                    }

                }
            }
        }

        private void PanelMonth_MouseClick(object sender, EventArgs e)
        {
            PanelDay pd = (PanelDay)sender;
            pd.BackColor = System.Drawing.Color.Green;
            datetime = new DateTime(dateTimePicker.Value.Year, dateTimePicker.Value.Month, Convert.ToInt32(pd.Solar));
            dateTimePicker.Value = datetime;
            DisplayPD(datetime);
        }

        private void PanelMonth_MouseEnter(object sender, EventArgs e)
        {
            PanelDay pd = (PanelDay)sender;
            if (dateTimePicker.Value.Year != datetime.Year || dateTimePicker.Value.Month != datetime.Month || dateTimePicker.Value.Day != Convert.ToInt32(pd.Solar))
            {
                pd.BackColor = System.Drawing.Color.DarkSeaGreen;
            }
        }

        private void PanelMonth_MouseLeave(object sender, EventArgs e)
        {
            PanelDay pd = (PanelDay)sender;
            if (dateTimePicker.Value.Year != datetime.Year || dateTimePicker.Value.Month != datetime.Month || dateTimePicker.Value.Day != Convert.ToInt32(pd.Solar))
            {
                pd.BackColor = System.Drawing.Color.Azure;
            }
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            datetime = dateTimePicker.Value;
            DisplayPD(datetime);
        }
    }
}
