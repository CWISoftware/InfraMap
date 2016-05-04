using System;
using System.Collections;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace InfraMap.Dominio.LDAP
{
    /// <summary>
    /// LDAP service.
    /// </summary>
    public static class LDAPService
    {
        /// <summary>
        /// Gets the display name of the user.
        /// </summary>
        /// <param name="login">The login to search.</param>
        /// <returns></returns>
        public static string GetUserDisplayName(string login)
        {
            if (login.Length == 0)
                return "";

            List<string> properties = new List<string> { "displayName", "sAMAccountName" };
            string filter = string.Format("(&(!(extensionAttribute9=Deleted))(objectCategory=user)(objectClass=user)(sAMAccountName={0}))", login);
            var searchResult = LdapSearch(filter, 1, properties, null);

            string result = string.Empty;
            if (searchResult != null && searchResult.Count != 0)
            {
                var directoryEntry = new DirectoryEntry(searchResult[0].Path);
                if ((directoryEntry.Properties["displayName"].Value != null) && (directoryEntry.Properties["sAMAccountName"].Value.ToString() == login))
                {
                    result = directoryEntry.Properties["displayName"].Value.ToString();
                }
                directoryEntry.Close();
            }

            return result;
        }

        /// <summary>
        /// Gets groups of the user.
        /// </summary>
        /// <param name="login">The login of the user to search.</param>
        /// <returns>Return a Dictionary<string, List<string>> of Organization Unit(key) and Common name list </returns>
        public static Dictionary<string, List<string>> GetUserGroups(string login)
        {
            List<string> properties = new List<string> { "memberOf", "sAMAccountName" };
            string filter =  string.Format("(&(!(extensionAttribute9=Deleted))(objectCategory=user)(objectClass=user)(sAMAccountName={0}))", login);
            var searchResult = LdapSearch(filter, 1, properties, null);

            Dictionary<string, List<string>> userGroups = new Dictionary<string, List<string>>();
            if (searchResult != null && searchResult.Count != 0)
            {
                var directoryEntry = new DirectoryEntry(searchResult[0].Path);
                object result = null;
                if ((directoryEntry.Properties["memberOf"].Value != null) && (directoryEntry.Properties["sAMAccountName"].Value.ToString() == login))
                {
                    result = directoryEntry.Properties["memberOf"].Value;
                    foreach (string s in (IList)result)
                    {
                        if (s.IndexOf("OU=") > 0)
                        {
                            //Example: s = "CN=SW-Nav Moderado,OU=SonicWALL,DC=cwinet,DC=local"
                            string key = s.Substring(s.IndexOf("OU=") + 3, s.IndexOf(",DC=") - s.IndexOf("OU=") - 3);
                            string value = s.Substring(s.IndexOf("CN=") + 3, s.IndexOf(",OU=") - s.IndexOf("CN=") - 3);

                            List<string> listValues;
                            if (!userGroups.TryGetValue(key, out listValues))
                                userGroups[key] = listValues = new List<string>();
                            listValues.Add(value);
                        }
                    }
                }
                directoryEntry.Close();
            }
            return userGroups;
        }

        /// <summary>
        /// Gets login of the user.
        /// </summary>
        /// <param name="name">The name of the user to search.</param>
        /// <returns></returns>
        public static string GetUserLogin(string name)
        {
            if (name.Length == 0)
                return "";

            List<string> properties = new List<string> { "displayName", "sAMAccountName" };
            string filter = string.Format("(&(!(extensionAttribute9=Deleted))(objectCategory=user)(objectClass=user)(displayName={0}*))", name);
            var searchResult = LdapSearch(filter, 1, properties, null);

            string result = string.Empty;
            if (searchResult != null && searchResult.Count != 0)
            {
                var directoryEntry = new DirectoryEntry(searchResult[0].Path);
                if ((directoryEntry.Properties["sAMAccountName"].Value != null) && (directoryEntry.Properties["displayName"].Value.ToString() == name))
                {
                    result = directoryEntry.Properties["sAMAccountName"].Value.ToString();
                }
                directoryEntry.Close();
            }

            return result;
        }

        /// <summary>
        /// Gets list of match user names.
        /// </summary>
        /// <param name="term">The name or part of user name.</param>
        /// <returns></returns>
        public static List<string> AutocompleteUsers(string term)
        {
            List<string> properties = new List<string> { "displayName" };
            string filter = string.Format("(&(!(extensionAttribute9=Deleted))(objectCategory=user)(objectClass=user)(memberOf=CN=gAllUsers,OU=OUGrupos,DC=cwinet,DC=local)(|(displayName={0}*)(givenName={0}*)(sn={0}*)))", term);
            var searchResult = LdapSearch(filter, 100, properties, null);

            List<string> users = new List<string>();
            if (searchResult != null && searchResult.Count != 0)
            {
                foreach (SearchResult result in searchResult)
                {
                    DirectoryEntry entry = result.GetDirectoryEntry();
                    string name = (entry.Properties["displayName"].Value ?? "").ToString();
                    if (!String.IsNullOrEmpty(name))
                    {
                        users.Add(name);
                    }
                }
            }
            return users;
        }

        /// <summary>
        /// Query on lpad, applying specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="rootEntry">The root entry.</param>
        /// <returns></returns>
        private static SearchResultCollection LdapSearch(string filter, int limit, List<string> properties, DirectoryEntry rootEntry = null)
        {
            if (rootEntry == null)
            {
                PrincipalContext pc = new PrincipalContext(ContextType.Domain);
                DirectoryEntry rootDse = new DirectoryEntry(@"LDAP://" + pc.ConnectedServer + @"/rootDSE");
                rootEntry = new DirectoryEntry(@"LDAP://" + pc.ConnectedServer + @"/" + rootDse.Properties["defaultNamingContext"].Value);
            }
            DirectorySearcher LdapSearcher = new DirectorySearcher(rootEntry);

            foreach(string s in properties)
            {
                LdapSearcher.PropertiesToLoad.Add(s);
            }

            LdapSearcher.Filter = filter;
            LdapSearcher.SizeLimit = limit;

            return LdapSearcher.FindAll();
        }
    }
}
