using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synchronizer.Configuration
{
	[ConfigurationCollection(typeof(RequestElement))]
	public class RequestElementCollection : ConfigurationElementCollection
	{
		protected override ConfigurationElement CreateNewElement()
		{
			return new RequestElement();
		}

		protected override object GetElementKey(ConfigurationElement element)
		{
			return ((RequestElement)element).Name;
		}
	}
}
