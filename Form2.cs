using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace ATM
{
    public partial class Form2 : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        Three f = new Three();
        String g;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
        void gender()
        {
            if (rdbm.Checked)
            {
                g = "Male";
            } else
            {
                g = "Female";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            f.getcon();
            gender();
            f.register(accno.Text, firstn.Text, lastn.Text, mobileno.Text, email.Text, dob.Text, nominame.Text, nomirel.Text, nomicon.Text, city.Text, g, pin.Text);
        }
    }
}
