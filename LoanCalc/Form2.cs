using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
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
            this.Text = "本息攤還";
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            dataGridView1.Rows.Clear();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e) { }

        private void button2_Click(object sender, EventArgs e) { }

        private void textBox3_TextChanged(object sender, EventArgs e) { }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            
        }
    }
}
