using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM
{
    public partial class Dashboard : Form
    {
        Form1 form1 = new Form1();
       
        public Dashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logged Out");
            this.Hide();
            form1.Show();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            label1.Text = "Welcome, " + Program.acno;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Balance balance = new Balance();
            balance.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChangePin change = new ChangePin();
            change.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Deposite deposite = new Deposite();
            deposite.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Withdraw withdraw = new Withdraw();
            withdraw.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MiniStatement mini = new MiniStatement();
            mini.Show();
            this.Hide();
        }
    }
}
