using System;
using System.Drawing;
using System.Windows.Forms;

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
            if (NullandZeroCheck(textBox1.Text) || NullandZeroCheck(textBox2.Text) || NullandZeroCheck(textBox3.Text))
            {
                MessageBox.Show("您輸入的數字有誤。", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            // if one or more of the textboxes is empty or null then throw an error
            else
            {
                dataGridView1.Rows.Clear(); // clears all data before calculation
                double IR = ((Math.Pow(1 + double.Parse(textBox3.Text) / 1200, double.Parse(textBox2.Text) * 12)) * double.Parse(textBox3.Text) / 1200) / (Math.Pow(1 + double.Parse(textBox3.Text) / 1200, double.Parse(textBox2.Text) * 12) - 1);
                double principal = double.Parse(textBox1.Text);

                double paymentPerMonth = principal * IR;
                double remP = double.Parse(textBox1.Text);
                double Mtot = 0, Itot = 0, Ptot = 0;

                for (int i = 1; i <= Math.Round(double.Parse(textBox2.Text) * 12); i++)
                {
                    dataGridView1.Rows.Add(Convert.ToString(i), Math.Round(paymentPerMonth - (remP * (double.Parse(textBox3.Text) / 1200))), Math.Round(remP * (double.Parse(textBox3.Text) / 1200)), Math.Round(paymentPerMonth, 0));

                    Mtot += paymentPerMonth - (remP * (double.Parse(textBox3.Text) / 1200));
                    Itot += remP * (double.Parse(textBox3.Text) / 1200);
                    Ptot += paymentPerMonth;

                    remP -= paymentPerMonth - (remP * (double.Parse(textBox3.Text) / 1200));
                }

                dataGridView1.Rows.Add("Total", Math.Round(Mtot), Math.Round(Itot), Math.Round(Ptot));
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

        private bool NullandZeroCheck(string txt)
        {
            if (String.IsNullOrEmpty(txt) || !double.TryParse(txt, out _) || double.Parse(txt) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
