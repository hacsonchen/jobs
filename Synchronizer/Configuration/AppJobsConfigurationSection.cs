using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synchronizer.Configuration
{
	public class AppJobsConfigurationSection : ConfigurationSection
	{

		private const string AppJobsPropertyName = "app-jobs";

		private const string RequestJobsPropertyName = "request-jobs";

        [ThreadStatic]
        private static AppJobsConfigurationSection current;

        /// <summary>
        /// The current <see cref="UnityConfigurationSection"/> that is being deserialized
        /// or being configured from.
        /// </summary>
        public static AppJobsConfigurationSection Current
        {
            get { return current; }
        }


        [ConfigurationProperty(RequestJobsPropertyName, IsDefaultCollection = true)]
		public RequestElementCollection RequestJobs
		{
			get 
			{ 
				var requestJobs = (RequestElementCollection)base[RequestJobsPropertyName];

				//requestJobs

				return requestJobs;
			}
		}

        public void Configure()
        {
            current = this;
        }
	}
}
