using System;
using System.Drawing;
using System.Windows.Forms;

namespace LoanCalc
{
    public partial class Form1 : Form
    {
        public Form1() { InitializeComponent(); }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false; // 禁用最大化按鈕
            this.MaximumSize = new Size(1280, 720); // 設定最大視窗大小為 1280x720
            this.MinimumSize = new Size(1280, 720); // 設定最小視窗大小為 1280x720
            this.Text = "Mortgage Calculator";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog(); //本息平均視窗
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog(); //本金平均視窗
        }

        private void label1_Click(object sender, EventArgs e) { }
    }
}
