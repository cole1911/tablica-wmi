using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace tsi_tablica
{
    public class LDAPConnector
    {
        private string[] servers = { @"dc1.labs.wmi.amu.edu.pl", @"dc2.labs.wmi.amu.edu.pl" };
        private string suffix = @"labs.wmi.amu.edu.pl";
        private int port = 636;
        private string root = @"DC=labs,DC=wmi,DC=amu,DC=edu,DC=pl";

        public bool checkLDAPUser(String username, String password)
        { 
            Console.Write("Validating credentials, result: ");
            LdapCredentailValidation lucv = new LdapCredentailValidation(servers, port, suffix, root);

            bool checkuser = lucv.CheckUserCredential(username, password);
            return checkuser;

        }

        public Hashtable getLDAPUserData(String username)
        {
            LdapAnonymousQuery laq = new LdapAnonymousQuery(servers, port, suffix, root);
            Hashtable result = laq.GetUserData(username);
            return result;
        }
    }
}