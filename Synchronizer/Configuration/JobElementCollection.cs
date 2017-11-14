using Synchronizer.Configuration.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synchronizer.Configuration
{
	[ConfigurationCollection(typeof(JobElement),AddItemName = "job")]
	public class JobElementCollection : DeserializableConfigurationElementCollection<JobElement>
	{
		protected override ConfigurationElement CreateNewElement()
		{
			return new JobElement();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((JobElement)element).Name;
		}
	}
}
