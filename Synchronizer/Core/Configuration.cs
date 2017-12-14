using Synchronizer.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synchronizer.Core
{
	public class JobsConfigurationSection : ConfigurationSection
	{
		[ConfigurationProperty("request", IsDefaultCollection = true)]
		public RequestElementCollection RequestJobs
		{
			get { return (RequestElementCollection)this["request"]; }
			set { }
		}

		[ConfigurationProperty("execute", IsDefaultCollection = true)]
		public ExecuteElementCollection ExecuteJobs
		{
			get { return (ExecuteElementCollection)this["execute"]; }
			set { }
		}
	}

	public class AppConfigurationManager
	{
		public static JobsConfigurationSection Jobs = ConfigurationManager.GetSection("app-jobs") as JobsConfigurationSection;
	}

	


}
