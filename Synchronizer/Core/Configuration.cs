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
		public static AppJobsConfigurationSection AppJobs = (AppJobsConfigurationSection)ConfigurationManager.GetSection("steve");

        public static JobElementCollection GetJobs()
        {
            AppJobs.Configure();
            return AppJobsConfigurationSection.Current.Jobs;
        }

	}
}
