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
    public partial class Deposite : Form
    {
        Three t = new Three();
        public Deposite()
        {
            InitializeComponent();
        }

        private void Deposite_Load(object sender, EventArgs e)
        {
            label1.Text = "Deposite into Account number " + Program.acno;

            string bal = t.findBalance();
            label3.Text = bal;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(amount.Text) <= 0)
            {
                MessageBox.Show("Amount should not be negative : ");
            } else
            {
                t.deposite(Convert.ToInt32(amount.Text));
                
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }
    }
}
