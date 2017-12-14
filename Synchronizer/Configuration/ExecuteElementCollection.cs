using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synchronizer.Configuration
{
	[ConfigurationCollection(typeof(ExecuteElement))]
	public class ExecuteElementCollection : ConfigurationElementCollection
	{
		protected override ConfigurationElement CreateNewElement()
		{
			return new ExecuteElement();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((ExecuteElement)element).Name;
		}
	}
}
