using System;
using System.Web.Security;
using BLToolkit.Data;

namespace WordPress.Web.Security
{
	public class WordpressMembershipProvider : MembershipProvider
	{
		class UserData
		{
			public int ID;
			public string user_pass;
		}

		public override bool ValidateUser(string name, string password)
		{
			if (string.IsNullOrWhiteSpace(name))
				return false;
			if (string.IsNullOrWhiteSpace(password))
				return false;


			UserData ud = null;
			using (var db = new DbManager())
			{
				db.SetCommand(@"SELECT id, user_pass FROM wp_users WHERE user_login=@user_login AND user_status=0",
					db.Parameter("user_login", name)
				);

				ud = db.ExecuteObject<UserData>();

			}

			if (null == ud)
				return false;

			return CryptSharp.PhpassCrypter.CheckPassword(password, ud.user_pass);
		}

		public override string ApplicationName { get; set; }

		public override string Description
		{
			get
			{
				return base.Description;
			}
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
		public override void Initialize(string name, System.Collections.Specialized.NameValueCollection config)
		{
			base.Initialize(name, config);
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

