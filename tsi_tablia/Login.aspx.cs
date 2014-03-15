using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace tsi_tablia
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["MySqlMembershipConnection"].ConnectionString;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                //connecting
                TextBox1.Text="OK";
                conn.Open();

                string sql = "SELECT `test_name` FROM `test` WHERE `test_id` = 1";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    TextBox2.Text= rdr[0].ToString();
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                //error
                TextBox1.Text = "NOT";
            }

            conn.Close();
            //done
            TextBox3.Text = "DONE";
        }

    }
}