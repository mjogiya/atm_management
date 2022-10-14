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
    public partial class MiniStatement : Form
    {
        Three t = new Three();
        DataSet ds;
        public MiniStatement()
        {
            InitializeComponent();
        }

        private void MiniStatement_Load(object sender, EventArgs e)
        {
            string bal = t.findBalance();
            label4.Text = bal;
            label5.Text = Program.acno;
            fillGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }
        void fillGrid()
        {
            t.getcon();
            ds = new DataSet();
            ds = t.trans();
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
