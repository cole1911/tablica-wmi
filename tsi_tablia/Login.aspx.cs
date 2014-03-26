using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace tsi_tablica
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

                conn.Open();

                string sql = "SELECT `test_name` FROM `test` WHERE `test_id` = 1";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                //error

            }

            conn.Close();
            //done

            loginBtn.Click += new EventHandler(loginBtn_ServerClick);

        }

        void loginBtn_ServerClick(object sender, EventArgs e)
        {
            LDAPConnector ldap = new LDAPConnector();
            if (ldap.checkLDAPUser(LoginBox.Text,PassBox.Text))
            {
                Hashtable userData = ldap.getLDAPUserData(LoginBox.Text);
                if (!userData.Equals(null))
                {
                    divResultSubmitted.InnerHtml = "Witaj " + userData["name"];
                }
                else
                {
                    divResultSubmitted.InnerHtml = "Coś poszło źle";
                }
            }
            //else
            //{
            //    divResultSubmitted.InnerHtml = "Nie ma takiego użytkownika";
           // }
        }

    }
}