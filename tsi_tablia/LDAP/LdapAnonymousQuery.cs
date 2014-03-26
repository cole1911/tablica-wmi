using System;
using System.DirectoryServices.Protocols;
using System.Collections;

namespace tsi_tablica
{
    class LdapAnonymousQuery
    {
        private string[] _ldapServers;
        private int _ldapPort;
        private string _userSuffix;
        private string _ldapRoot;

        public LdapAnonymousQuery(String[] Servers, Int32 Port, String UserSuffix, String LdapRoot)
        {
            _ldapServers = Servers;
            _userSuffix = UserSuffix;
            _ldapPort = Port;
            _ldapRoot = LdapRoot;
        }

        public Hashtable GetUserData(String Login)
        {
            try
            {
                LdapDirectoryIdentifier ldi = new LdapDirectoryIdentifier(_ldapServers, _ldapPort, true, false);
                LdapConnection lc = new LdapConnection(ldi);
                lc.AuthType = AuthType.Anonymous;
                lc.Bind();

                string filter = String.Format("(&(objectCategory=person)(sAMAccountName={0}))", Login);
                string[] attributesToReturn = { "sAMAccountName", "givenname", "sn", "mail" };

                SearchRequest sreq = new SearchRequest(_ldapRoot, filter, SearchScope.Subtree, attributesToReturn);
                SearchResponse sres = lc.SendRequest(sreq) as SearchResponse;

                Hashtable userData = new Hashtable();

                foreach (SearchResultEntry result in sres.Entries)
                {
                  //  Console.Write("First Name: ");
                    foreach (string i in result.Attributes["givenname"].GetValues(typeof(String))) { userData.Add("name", i); }
                   // Console.WriteLine();

                   // Console.Write("Last Name: ");
                    foreach (string i in result.Attributes["sn"].GetValues(typeof(String))) { userData.Add("surname", i); }
                  //  Console.WriteLine();

                   // Console.Write("Email: ");
                    foreach (string i in result.Attributes["mail"].GetValues(typeof(String))) { userData.Add("mail", i); ; }
                    //Console.WriteLine();
                }

                return userData;

            }
            catch (Exception e)
            {
                return null;
            }
        }


    }
}
