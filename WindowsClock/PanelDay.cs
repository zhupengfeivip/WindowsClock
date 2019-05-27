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
    public partial class PanelDay : UserControl
    {
        public PanelDay()
        {
            InitializeComponent();
            this.labelSolar.Enabled = false;
            this.labelLunar.Enabled = false;
            this.labelTerms.Enabled = false;
        }


        private string strSolar = "";
        private string strLunar = "";
        private string strTerms = "";
        private MyDrawingMode myDrawingMode;

        public string Solar
        {
            get { return strSolar; }
            set
            {
                strSolar = value;
                labelSolar.Text = strSolar;
            }
        }

        public string Lunar
        {
            get { return strLunar; }
            set
            {
                strLunar = value;
                labelLunar.Text = strLunar;
            }
        }

        public string Terms
        {
            get { return strTerms; }
            set
            {
                strTerms = value;
                labelTerms.Text = strTerms;
                workTerms();
            }
        }

        public enum MyDrawingMode
        {
            Default = 0,
            Terms = 1
        }

        public MyDrawingMode DrawingMode
        {
            get { return myDrawingMode; }
            set
            {
                myDrawingMode = value;
                workDM();
            }
        }

        private void workDM()
        {
            switch (myDrawingMode)
            {
                case MyDrawingMode.Default:
                    labelSolar.Location = new System.Drawing.Point(0, 0);
                    labelSolar.Size = new System.Drawing.Size(56, 40);
                    labelLunar.Location = new System.Drawing.Point(0, 40);
                    labelLunar.Size = new System.Drawing.Size(56, 20);
                    labelTerms.Location = new System.Drawing.Point(0, 45);
                    labelTerms.Size = new System.Drawing.Size(56, 15);
                    labelTerms.Visible = false;
                    break;
                case MyDrawingMode.Terms:
                    labelSolar.Location = new System.Drawing.Point(0, 0);
                    labelSolar.Size = new System.Drawing.Size(56, 30);
                    labelLunar.Location = new System.Drawing.Point(0, 30);
                    labelLunar.Size = new System.Drawing.Size(56, 15);
                    labelTerms.Location = new System.Drawing.Point(0, 45);
                    labelTerms.Size = new System.Drawing.Size(56, 15);
                    labelTerms.Visible = true;
                    break;
                default:
                    labelSolar.Location = new System.Drawing.Point(0, 0);
                    labelSolar.Size = new System.Drawing.Size(56, 40);
                    labelLunar.Location = new System.Drawing.Point(0, 40);
                    labelLunar.Size = new System.Drawing.Size(56, 20);
                    labelTerms.Location = new System.Drawing.Point(0, 45);
                    labelTerms.Size = new System.Drawing.Size(56, 15);
                    labelTerms.Visible = false;
                    break;
            }
        }

        private void workTerms()
        {
            if (strTerms == string.Empty) myDrawingMode = MyDrawingMode.Default;
            else myDrawingMode = MyDrawingMode.Terms;
            workDM();
        }
    }
}
