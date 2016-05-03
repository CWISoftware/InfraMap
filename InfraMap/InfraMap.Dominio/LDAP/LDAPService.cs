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

            List<string> properties = new List<string> { "displayName" };
            string filter = string.Format("(&(!(extensionAttribute9=Deleted))(objectCategory=user)(objectClass=user)(sAMAccountName={0}))", login);
            var searchResult = LdapSearch(filter, 1, properties, null);

            string result = string.Empty;
            if (searchResult != null && searchResult.Count != 0)
            {
                var directoryEntry = new DirectoryEntry(searchResult[0].Path);
                result = directoryEntry.Properties["displayName"].Value != null ? directoryEntry.Properties["displayName"].Value.ToString() : "";
                directoryEntry.Close();
            }

            return result;
        }

        /// <summary>
        /// Gets groups of the user.
        /// </summary>
        /// <param name="login">The login of the user to search.</param>
        /// <returns></returns>
        public static List<string> GetUserGroups(string login)
        {
            if (login.Length == 0)
                return null;

            List<string> properties = new List<string> { "memberOf" };
            string filter =  string.Format("(&(!(extensionAttribute9=Deleted))(objectCategory=user)(objectClass=user)(sAMAccountName={0}))", login);
            var searchResult = LdapSearch(filter, 1, properties, null);

            List<string> userListGroups = new List<string>();
            if (searchResult != null && searchResult.Count != 0)
            {
                var directoryEntry = new DirectoryEntry(searchResult[0].Path);
                object result = directoryEntry.Properties["memberOf"].Value != null ? directoryEntry.Properties["memberOf"].Value : null;
                foreach( string s in (IList)result)
                {
                    userListGroups.Add(s.Substring( s.IndexOf("=")+1, s.IndexOf(",")-s.IndexOf("=")-1));
                }
                directoryEntry.Close();
            }

            return userListGroups;
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

            List<string> properties = new List<string> { "displayName" };
            string filter = string.Format("(&(!(extensionAttribute9=Deleted))(objectCategory=user)(objectClass=user)(displayName={0}*))", name);
            var searchResult = LdapSearch(filter, 1, properties, null);

            string result = string.Empty;
            if (searchResult != null && searchResult.Count != 0)
            {
                var directoryEntry = new DirectoryEntry(searchResult[0].Path);
                result = directoryEntry.Properties["sAMAccountName"].Value != null ? directoryEntry.Properties["sAMAccountName"].Value.ToString() : "";
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
            if (term.Length == 0)
                return null;

            List<string> properties = new List<string> { "displayName" };
            string filter = string.Format("(&(!(extensionAttribute9=Deleted))(objectCategory=user)(objectClass=user)(|(displayName={0}*)(givenName={0}*)(sn={0}*)))", term);
            var searchResult = LdapSearch(filter, 100, properties, null);

            List<string> persons = new List<string>();
            if (searchResult != null && searchResult.Count != 0)
            {
                foreach (SearchResult result in searchResult)
                {
                    DirectoryEntry entry = result.GetDirectoryEntry();
                    string name = (entry.Properties["displayName"].Value ?? "").ToString();
                    if (!String.IsNullOrEmpty(name))
                    {
                        persons.Add(name);
                    }
                }
            }
            return persons;
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
