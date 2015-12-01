using System;
using System.Configuration;
using System.Configuration.Provider;
using System.Web.Security;

using System.Data;
using MySql.Data.MySqlClient;

namespace WordPress.Providers.MySql
{
	public class TableNameUtility
	{
		private string _Prefix;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="prefix">Prefix of WP tables</param>
		public TableNameUtility(string prefix)
		{
			this._Prefix = prefix;
		}

		#region Tables
		public string TableUser
		{
			get
			{
				return this._Prefix + "users";
			}
		}
		#endregion
	}
}

