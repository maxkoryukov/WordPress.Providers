using System;
using System.Web.Security;
using BLToolkit.Data;

namespace WordPress.Web.Security
{
	public class WordpressRoleProvider : RoleProvider
	{
		public override string ApplicationName{get;set;}

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

