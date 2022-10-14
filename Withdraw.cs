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
    public partial class Withdraw : Form
    {
        Three t = new Three();
        int oldbal;
        public Withdraw()
        {
            InitializeComponent();
        }

        private void Withdraw_Load(object sender, EventArgs e)
        {
            label1.Text = "Withdraw into Account number " + Program.acno;

            string bal = t.findBalance();
            label3.Text = bal;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(amount.Text) <= 0)
            {
                MessageBox.Show("Amount should not be negative : ");
            }
            else
            {
                string bal = t.findBalance();
                oldbal = Convert.ToInt32(bal);
                if(oldbal-Convert.ToInt32(amount.Text) <= 0)
                {
                    MessageBox.Show("Not Enough Balance ");
                } else
                {
                    t.withdraw(Convert.ToInt32(amount.Text));
                    Dashboard dashboard = new Dashboard();
                    dashboard.Show();
                    this.Hide();
                }

            }
        }
    }
}
