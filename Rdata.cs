using RDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Rdata : Form
    {
        public Rdata()
        {
            InitializeComponent();

            var envPath = Environment.GetEnvironmentVariable("PATH");
            var rBinPath = @"C:\Program Files\R_32\R-3.4.4\bin\i386";
            Environment.SetEnvironmentVariable("PATH", envPath + Path.PathSeparator + rBinPath);
            Console.Write(envPath + Path.PathSeparator + rBinPath);
       
            using (REngine engine = REngine.CreateInstance("RDotNet"))
            {
                engine.Initialize();

                NumericVector group1 = engine.CreateNumericVector(new double[] { 30.02, 29.99, 30.11, 29.97, 30.01, 29.99 });
                engine.SetSymbol("group1", group1);

                NumericVector group2 = engine.Evaluate("group2 <- c(29.89, 29.93, 29.72, 30.02, 29.98, 29.98)").AsNumeric();

                GenericVector testResult = engine.Evaluate("t.test(group1, group2)").AsList();
                double p = testResult["p.value"].AsNumeric().First();

                listBox1.Items.Add(string.Join(", ", group1));
                listBox1.Items.Add(string.Join(", ", group2));
                listBox1.Items.Add(p.ToString());

             
                chart1.ChartAreas[0].AxisX.IsLabelAutoFit = false;
                chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 90;
                chart1.ChartAreas[0].AxisX.Interval = 1;

                for(int i=0; i<6; i++)
                {
                    chart1.Series[0].Points.AddXY(i, group1[i]);
                    chart1.Series[0].Points.AddXY(i, group2[i]);

                }
            }
        }
    }
}
