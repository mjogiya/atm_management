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
            cmd = new SqlCommand("insert into holder (accountno, firstn, lastn, mobileno, email, dob, nomineename, nomineerel, nomineecontact, city, gender, pin) values('"+accno+"', '"+firstn+ "', '" + lastn + "', '" + mobileno + "', '" + email + "', '" + dob + "', '"+nominame+ "', '"+nomirel+ "', '"+nomicon+ "', '"+city+ "', '"+gender+ "', '"+pin+"'); ", con);
            cmd.ExecuteNonQuery();
        }
        public void login(String accno, String pin)
        {
            getcon();
             
        }
    }
}
