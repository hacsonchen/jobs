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

		private const string AppJobsPropertyName = "steve";

		private const string JobsPropertyName = "jobs";

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


        [ConfigurationProperty(JobsPropertyName, IsDefaultCollection = true)]
		public JobElementCollection Jobs
		{
			get 
			{ 
				return (JobElementCollection)base[JobsPropertyName];
			}
		}

        public void Configure()
        {
            current = this;
        }


	}
}
