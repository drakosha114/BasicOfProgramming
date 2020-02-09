using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5Calculator
{
    public partial class Form1 : Form
    {

        public int value { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") {
                textBox2.Text = "";
                return;
            }

            int value = int.Parse(textBox1.Text);
            textBox2.Text = (CalculateValue(value)).ToString();
        }

        private double CalculateValue(int val) {

            double e_exp_2 = Math.Exp(2);
            double e_exp_val = Math.Exp(val);
            double e_exp_val_1 = Math.Exp(val + 1);
            double e_exp_val_2 = Math.Exp(val + 2);
            double tg = Math.Tan(val);
            double sin = Math.Sin(val);

            double sum1 = ((e_exp_val_1 * e_exp_val_2) / e_exp_val_1) + ((Math.Sqrt(e_exp_val) + tg) / Math.Log10(sin + e_exp_2));
            double sum2 = val * e_exp_2;


            return Math.Pow(sum1, 1/3) + sum2;
        }
    }
}
