using System;
using System.Configuration;
using System.Configuration.Provider;
using System.Web.Security;

namespace WordPress.Providers.MySql
{
	public class WordpressRoleProvider : RoleProvider
	{
		internal protected TableNameUtility N;
		public string ConnectionStringName { get; private set; }
		public string ConnectionString { get; private set; }
		public override string ApplicationName { get; set;  }
		public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
		{
			base.Initialize(name, config);

			var c = InternalConfigurationHelper.Initialize(config);

			this.ConnectionString = c.ConnectionString;
			this.ConnectionStringName = c.ConnectionStringName;
			this.N = c.N;
		}

		#region Dummy Implementation
		public override bool IsUserInRole(string username, string rolename)
		{
			if (null != rolename)
				rolename = rolename.ToLower();
			
			if ("administrator" == rolename)
				return true;
			
			return false;
		}

		public override string[] GetRolesForUser(string username)
		{
			return new string[] {"Administrator"};
		}
		#endregion

		#region Not Implemented

		public override void AddUsersToRoles(string[] usernames, string[] rolenames)
		{
			throw new NotImplementedException();
		}
			
		public override void CreateRole(string rolename)
		{
			throw new NotImplementedException();
		}

		public override bool DeleteRole(string rolename, bool throwOnPopulatedRole)
		{
			throw new NotImplementedException();
		}

		public override string[] FindUsersInRole(string roleName, string usernameToMatch)
		{
			throw new NotImplementedException();
		}

		public override string[] GetAllRoles()
		{
			throw new NotImplementedException();
		}
			
		public override string[] GetUsersInRole(string rolename)
		{
			throw new NotImplementedException();
		}
			
		public override void RemoveUsersFromRoles(string[] usernames, string[] rolenames)
		{
			throw new NotImplementedException();
		}

		public override bool RoleExists(string rolename)
		{
			throw new NotImplementedException();
		}


		#endregion
	}
}

