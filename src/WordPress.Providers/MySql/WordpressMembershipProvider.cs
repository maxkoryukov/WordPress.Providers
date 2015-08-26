using System;
using System.Configuration;
using System.Configuration.Provider;
using System.Web.Security;

using System.Data;
using MySql.Data.MySqlClient;

namespace WordPress.Providers.MySql
{
	public class WordpressMembershipProvider : MembershipProvider
	{
		public string ConnectionStringName { get; private set; }
		public string ConnectionString { get; private set; }

		public override bool ValidateUser(string name, string password)
		{
			if (string.IsNullOrWhiteSpace(name))
				return false;
			if (string.IsNullOrWhiteSpace(password))
				return false;

			string hash = null;
			string id = null;

			using (DataTable dt = new DataTable())
			{
				dt.TableName = "wp_users";
				using (var cn = new MySqlConnection(this.ConnectionString))
				{
					cn.Open();
					using (var cmd = new MySqlCommand(
						"SELECT id, user_pass FROM wp_users WHERE user_login=@user_login AND user_status=0",
						cn))
					{
						cmd.Parameters.AddWithValue("user_login", name);

						new MySqlDataAdapter(cmd).Fill(dt);
					}
				}

				if (dt.Rows.Count == 1)
				{
					hash = dt.Rows[0]["user_pass"].ToString();
					id = dt.Rows[0]["id"].ToString();
				}
			}

			if (string.IsNullOrWhiteSpace(id))
				return false;

			if (string.IsNullOrWhiteSpace(hash))
				return false;

			return CryptSharp.PhpassCrypter.CheckPassword(password, hash);
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

			if (null == config["connectionStringName"])
				throw new ArgumentNullException("connectionStringName");
			this.ConnectionStringName = config["connectionStringName"];

			ConnectionStringSettings ConnectionStringSettings =
				ConfigurationManager.ConnectionStrings[this.ConnectionStringName];

			if (ConnectionStringSettings == null)
				throw new ProviderException("Connection string was not found in config file.");
			
			if (string.IsNullOrWhiteSpace(ConnectionStringSettings.ConnectionString))
				throw new ProviderException("Connection string cannot be empty.");

			this.ConnectionString = ConnectionStringSettings.ConnectionString;
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
		public override bool ChangePassword(string name, string oldPwd, string newPwd)
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

