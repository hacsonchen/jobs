using Synchronizer.Configuration.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synchronizer.Configuration
{
	public class RequestElement : DeserializableConfigurationElement
	{

		[ConfigurationProperty("url", IsRequired = true, DefaultValue = "http://localhost")]
		[RegexStringValidator(@"http?\://\S+")]
		public string Url
		{
			get { return (string)this["url"]; }
			set { }
		}

		[ConfigurationProperty("type", IsRequired = false, DefaultValue = "GET")]
		public string Type
		{
			get { return (string)this["type"]; }
			set { }
		}

		[ConfigurationProperty("datatype", IsRequired = false, DefaultValue = "JSON")]
		public string DataType
		{
			get { return (string)this["datatype"]; }
			set { }
		}

		[ConfigurationProperty("data", IsRequired = false, DefaultValue = "")]
		public string Data
		{
			get { return (string)this["data"]; }
			set { }
		}


	}
}
