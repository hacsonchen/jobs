using Synchronizer.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synchronizer.Core
{
	public class AppConfigurationManager
	{
		public static AppJobsConfigurationSection Jobs = (AppJobsConfigurationSection)ConfigurationManager.GetSection("app-jobs");

        public static RequestElementCollection GetRequestJobs()
        {
            Jobs.Configure();
            return AppJobsConfigurationSection.Current.RequestJobs;
        }

	}
}
