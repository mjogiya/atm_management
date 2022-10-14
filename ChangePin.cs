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

    public partial class ChangePin : Form
    {
        Three t = new Three();
        public ChangePin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(confirm.Text == newp.Text)
            {
               string log = t.changepin(old.Text, newp.Text);
                if(log == "Success")
                {
                    MessageBox.Show("PIN Updated");
                } else
                {
                    MessageBox.Show("Old PIN Wrong");
                }
            } else
            {
                MessageBox.Show("New and Confirm pin does not match :(");
            }
        }
    }
}
