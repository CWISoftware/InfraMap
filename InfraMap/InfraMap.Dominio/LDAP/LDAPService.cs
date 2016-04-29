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
        /// <param name="stringToSearch">The login / ginMunber to search.</param>
        /// <returns></returns>
        public static string GetUserDisplayName(string stringToSearch)
        {
            string displayName = string.Empty;
            string filter = null;
            Int64 ginNumber = 0;

            // Verify if is a number
            if (Int64.TryParse(stringToSearch, out ginNumber))
            {
                string formattedGIN = ginNumber.ToString("D8");
                filter = string.Format("(&(!(extensionAttribute9=Deleted))(objectCategory=user)(objectClass=user)(employeeNumber={0}))", formattedGIN);
            }
            else
            {
                filter = string.Format("(&(!(extensionAttribute9=Deleted))(objectCategory=user)(objectClass=user)(|(displayName={0}*)(cn={0}*)(sAMAccountName={0})))", stringToSearch);
            }

            var searchResult = LdapSearch(filter, 1, null);

            if (searchResult != null && searchResult.Count != 0)
            {
                var directoryEntry = new DirectoryEntry(searchResult[0].Path);
                displayName = directoryEntry.Properties["displayName"].Value != null ? directoryEntry.Properties["displayName"].Value.ToString() : "";
                directoryEntry.Close();
            }

            return displayName;
        }

        /// <summary>
        /// Gets groups of the user.
        /// </summary>
        /// <param name="login">The login of the user to search.</param>
        /// <returns></returns>
        public static List<string> GetUserGroups(string login)
        {
            List<string> userListGroups = new List<string>();
            object result = null;
            string filter = null;

            filter = string.Format("(&(!(extensionAttribute9=Deleted))(objectCategory=user)(objectClass=user)(|(displayName={0}*)(cn={0}*)(sAMAccountName={0})))", login);

            var searchResult = LdapSearch(filter, 1, null);

            if (searchResult != null && searchResult.Count != 0)
            {
                var directoryEntry = new DirectoryEntry(searchResult[0].Path);
                result = directoryEntry.Properties["memberOf"].Value != null ? directoryEntry.Properties["memberOf"].Value : null;
                foreach( string s in (IList)result)
                {
                    userListGroups.Add(s.Substring( s.IndexOf("=")+1, s.IndexOf(",")-s.IndexOf("=")-1));
                }
                directoryEntry.Close();
            }

            return userListGroups;
        }

        /// <summary>
        /// Query on lpad, applying specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="rootEntry">The root entry.</param>
        /// <returns></returns>
        private static SearchResultCollection LdapSearch(string filter, int limit, DirectoryEntry rootEntry = null)
        {
            SearchResultCollection searchResult = null;

            if (rootEntry == null)
            {
                PrincipalContext pc = new PrincipalContext(ContextType.Domain);
                DirectoryEntry rootDse = new DirectoryEntry(@"LDAP://" + pc.ConnectedServer + @"/rootDSE");
                rootEntry = new DirectoryEntry(@"LDAP://" + pc.ConnectedServer + @"/" + rootDse.Properties["defaultNamingContext"].Value);
            }

            DirectorySearcher LdapSearcher = new DirectorySearcher(rootEntry);
            LdapSearcher.PropertiesToLoad.Add("sAMAccountName");
            LdapSearcher.PropertiesToLoad.Add("displayName");
            LdapSearcher.PropertiesToLoad.Add("memberOf");

            LdapSearcher.Filter = filter;
            LdapSearcher.SizeLimit = limit;
            searchResult = LdapSearcher.FindAll();

            return searchResult;
        }
    }
}
