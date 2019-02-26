using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChartsSandbox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            fillChart();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void fillChart()
        {
            //AddXY value in chart1 in series named as Salary  
            chart1.Series["Salary"].Points.AddXY("Ajay", "10000");
            chart1.Series["Salary"].Points.AddXY("Ramesh", "8000");
            chart1.Series["Salary"].Points.AddXY("Ankit", "7000");
            chart1.Series["Salary"].Points.AddXY("Gurmeet", "10000");
            chart1.Series["Salary"].Points.AddXY("Suresh", "8500");
            //chart title  
            chart1.Titles.Add("Salary Chart");
        }
    }
}
