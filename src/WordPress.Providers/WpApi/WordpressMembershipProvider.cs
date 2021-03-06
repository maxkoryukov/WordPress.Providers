﻿using System;
using System.Configuration;
using System.Configuration.Provider;
using System.Web.Security;

using System.Data;
using MySql.Data.MySqlClient;

namespace WordPress.Providers.WpApi
{
	public class WordpressMembershipProvider : MembershipProvider
	{
		public string ConnectionUrlName { get; private set; }

		protected string ConnectionUrl
		{
			get
			{
				return System.Configuration.ConfigurationManager.AppSettings[this.ConnectionUrlName];
			}
		}

		public override string ApplicationName { get; set; }

		public override string Description
		{
			get
			{
				return base.Description;
			}
		}
		public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
		{
			base.Initialize(name, config);

			if (null == config["connectionUrlName"])
				throw new ArgumentNullException("connectionUrlName");
			this.ConnectionUrlName = config["connectionUrlName"];

			if (string.IsNullOrWhiteSpace(this.ConnectionUrlName))
				throw new ProviderException("ConnectionUrlName cannot be empty.");

			if (string.IsNullOrWhiteSpace(this.ConnectionUrl))
				throw new ProviderException("ConnectionUrl (defined in config file) cannot be empty.");
		}

		public override bool EnablePasswordReset
		{ 
			get { return false; } 
		}
		public override bool EnablePasswordRetrieval
		{ 
			get { return false; } 
		}
		public override int MaxInvalidPasswordAttempts
		{
			get { return 0; } 
		}
		public override int MinRequiredNonAlphanumericCharacters
		{
			get { return 0; } 
		}
		public override int MinRequiredPasswordLength
		{
			get { return 0; } 
		}
		public override bool RequiresQuestionAndAnswer
		{
			get { return false; } 
		}
		public override bool RequiresUniqueEmail
		{
			get { return false; } 
		}
		#region NotImplemented
		public override bool ValidateUser(string name, string password)
		{
			throw new NotImplementedException();
		}
		public override bool ChangePassword(string name, string old_password, string new_password)
		{
			throw new NotImplementedException();
		}

		public override bool ChangePasswordQuestionAndAnswer(string name, string password, string newPwdQuestion, string newPwdAnswer)
		{
			throw new NotImplementedException();
		}

		public override MembershipUser CreateUser(string username, string password, string email, string pwdQuestion, string pwdAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
		{
			throw new NotImplementedException();
		}

		protected override byte[] DecryptPassword(byte[] encodedPassword)
		{
			return base.DecryptPassword(encodedPassword);
		}
		public override bool DeleteUser(string name, bool deleteAllRelatedData)
		{
			throw new NotImplementedException();
		}
		protected override byte[] EncryptPassword(byte[] password)
		{
			return base.EncryptPassword(password);
		}
		protected override byte[] EncryptPassword(byte[] password, System.Web.Configuration.MembershipPasswordCompatibilityMode legacyPasswordCompatibilityMode)
		{
			return base.EncryptPassword(password, legacyPasswordCompatibilityMode);
		}
		public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
		{
			throw new NotImplementedException();
		}
		public override MembershipUserCollection FindUsersByName(string nameToMatch, int pageIndex, int pageSize, out int totalRecords)
		{
			throw new NotImplementedException();
		}
		public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
		{
			throw new NotImplementedException();
		}
		public override int GetNumberOfUsersOnline()
		{
			throw new NotImplementedException();
		}
		public override string GetPassword(string name, string answer)
		{
			throw new NotImplementedException();
		}
		public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
		{
			throw new NotImplementedException();
		}
		public override MembershipUser GetUser(string name, bool userIsOnline)
		{
			throw new NotImplementedException();
		}
		public override string GetUserNameByEmail(string email)
		{
			throw new NotImplementedException();
		}
		public override string Name
		{
			get
			{
				return base.Name;
			}
		}
		protected override void OnValidatingPassword(ValidatePasswordEventArgs args)
		{
			base.OnValidatingPassword(args);
		}
		public override int PasswordAttemptWindow
		{
			get
			{
				throw new NotImplementedException();
			}
		}
		public override MembershipPasswordFormat PasswordFormat
		{
			get
			{
				throw new NotImplementedException();
			}
		}
		public override string PasswordStrengthRegularExpression
		{
			get
			{
				throw new NotImplementedException();
			}
		}
		public override string ResetPassword(string name, string answer)
		{
			throw new NotImplementedException();
		}
		public override bool UnlockUser(string userName)
		{
			throw new NotImplementedException();
		}
		public override void UpdateUser(MembershipUser user)
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}

