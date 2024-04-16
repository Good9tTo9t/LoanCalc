using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LoanCalc
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false; // 禁用最大化按鈕
            this.MaximumSize = new Size(1280, 720); // 設定最大視窗大小為 1280x720
            this.MinimumSize = new Size(1280, 720); // 設定最小視窗大小為 1280x720
            this.Text = "本息攤還"; // set title
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            dataGridView1.Rows.Clear(); // clears all data
        } //clear button

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear(); // clears all data before calculation
            double IR = ((Math.Pow(1 + double.Parse(textBox3.Text) / 1200, double.Parse(textBox2.Text) * 12)) * double.Parse(textBox3.Text) / 1200) / (Math.Pow(1 + double.Parse(textBox3.Text) / 1200, double.Parse(textBox2.Text) * 12) - 1);
            for (int i = 1; i <= int.Parse(textBox2.Text) * 12; i++)
            {
                dataGridView1.Rows.Add(Convert.ToString(i));
            }
        } //enter button

        private void checkDigit(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            // only numbers can be entered
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            // only the first decimal point can be entered
        }
    }
}
