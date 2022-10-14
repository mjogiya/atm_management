using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ATM
{
    class Three
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;

        public void getcon()
        {
            con = new SqlConnection(Program.db);
            con.Open();
        }

        public void register(String accno, String firstn, String lastn,  String mobileno, String email, String dob, String nominame, String nomirel, String nomicon, String city, String gender, String pin)
        {
            getcon();
            cmd = new SqlCommand("insert into holder (accountno, firstn, lastn, mobileno, email, dob, nomineename, nomineerel, nomineecontact, city, gender, pin, registerdate) values('"+accno+"', '"+firstn+ "', '" + lastn + "', '" + mobileno + "', '" + email + "', '" + dob + "', '"+nominame+ "', '"+nomirel+ "', '"+nomicon+ "', '"+city+ "', '"+gender+ "', '"+pin+"', '"+DateTime.Now.ToString()+"');", con);
            cmd.ExecuteNonQuery();
        }
        public String login(String accno, String pin)
        {
            getcon();
            da = new SqlDataAdapter("SELECT * from holder where accountno='" + accno + "' AND pin='" + pin + "';", con);
            ds = new DataSet();
            da.Fill(ds);
            int i = ds.Tables[0].Rows.Count;
            if(i == 1)
            {
                Program.acno = accno;
                return "login";
            } else
            {
                return "login falied";
            }

        }
        public string findBalance()
        {
            getcon();
            da = new SqlDataAdapter("SELECT balance from holder where accountno='" + Program.acno + "';", con);
            ds = new DataSet();
            da.Fill(ds);
            string balace = ds.Tables[0].Rows[0]["balance"].ToString();
            return balace;
        }
        public string changepin(String oldp, String pin)
        {
            getcon();
            da = new SqlDataAdapter("SELECT pin from holder where accountno='" + Program.acno + "';", con);
            ds = new DataSet();
            da.Fill(ds);
            string oldpin = ds.Tables[0].Rows[0]["pin"].ToString();
            if(oldpin == oldp)
            {
                SqlCommand cmd = new SqlCommand("update holder set pin = '"+pin+"' where accountno = '"+Program.acno+"'", con);
                cmd.ExecuteNonQuery();
                return "Success";
            } else
            {
                return "failed";
            }
        }
        public String deposite(int amo)
        {
            getcon();
            da = new SqlDataAdapter("SELECT balance from holder where accountno='" + Program.acno + "';", con);
            ds = new DataSet();
            da.Fill(ds);
            int oldbal = Convert.ToInt32(ds.Tables[0].Rows[0]["balance"]);
            int newbal = oldbal + amo;

            SqlCommand cmd = new SqlCommand("update holder set balance = '" + newbal + "' where accountno = '" + Program.acno + "'", con);
            cmd.ExecuteNonQuery();
            SqlCommand cmd1 = new SqlCommand("insert into [Transaction] (Account_NO, T_Type, Old_Balance, Amount, New_Balance, T_Date) values('" + Program.acno + "', 'Deposite', '" + oldbal + "', '" + amo + "', '" + newbal + "', '"+DateTime.Now.ToString()+"');", con);
            cmd1.ExecuteNonQuery();
            return "Success";
        }
        public String withdraw(int amo)
        {
            getcon();
            da = new SqlDataAdapter("SELECT balance from holder where accountno='" + Program.acno + "';", con);
            ds = new DataSet();
            da.Fill(ds);
            int oldbal = Convert.ToInt32(ds.Tables[0].Rows[0]["balance"]);
            int newbal = oldbal - amo;

            SqlCommand cmd = new SqlCommand("update holder set balance = '" + newbal + "' where accountno = '" + Program.acno + "'", con);
            cmd.ExecuteNonQuery();
            SqlCommand cmd1 = new SqlCommand("insert into [Transaction] (Account_NO, T_Type, Old_Balance, Amount, New_Balance, T_Date) values('" + Program.acno + "', 'Withdraw', '" + oldbal + "', '" + amo + "', '" + newbal + "', '"+DateTime.Now.ToString()+"');", con);
            cmd1.ExecuteNonQuery();
            return "Success";
        }

        public DataSet trans()
        {
            getcon();
            da = new SqlDataAdapter("SELECT * FROM [Transaction] where Account_NO='" + Program.acno+"';", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

    }
}
