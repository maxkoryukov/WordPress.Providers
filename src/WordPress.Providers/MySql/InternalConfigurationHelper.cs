using System;
using System.Configuration;
using System.Configuration.Provider;
using System.Web.Security;
using System.Collections.Specialized;


namespace WordPress.Providers.MySql
{
	internal static class InternalConfigurationHelper
	{
		internal class InternalConfiguration
		{
			public string ConnectionString;
			public string ConnectionStringName;
			public TableNameUtility N;
		}

		public static InternalConfiguration Initialize(NameValueCollection config)
		{
			var res = new InternalConfiguration();

			if (null == config["connectionStringName"])
				throw new ArgumentNullException("connectionStringName");
			res.ConnectionStringName = config["connectionStringName"];

			ConnectionStringSettings ConnectionStringSettings =
				ConfigurationManager.ConnectionStrings[res.ConnectionStringName];

			if (ConnectionStringSettings == null)
				throw new ProviderException("Connection string was not found in config file.");

			if (string.IsNullOrWhiteSpace(ConnectionStringSettings.ConnectionString))
				throw new ProviderException("Connection string cannot be empty.");

			res.ConnectionString = ConnectionStringSettings.ConnectionString;

			string prefix;
			if (null != config["tablePrefix"])
				prefix = config["tablePrefix"];
			else
				prefix = "wp_";
			res.N = new TableNameUtility(prefix);

			return res;
		}
	}
}

