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
	}

	public class AppConfigurationManager
	{
		public static JobsConfigurationSection Jobs = ConfigurationManager.GetSection("app-jobs") as JobsConfigurationSection;
	}

	public class RequestElement : ConfigurationElement
	{
		[ConfigurationProperty("jobname", IsKey = true, IsRequired = true)]
		public string Name
		{
			get { return (string)this["jobname"]; }
			set { }
		}

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

		[ConfigurationProperty("expression", IsRequired = false, DefaultValue = "")]
		public string Expression
		{
			get { return (string)this["expression"]; }
			set { }
		}
	}

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
