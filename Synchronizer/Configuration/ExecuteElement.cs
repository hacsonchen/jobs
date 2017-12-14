using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synchronizer.Configuration
{
	public class ExecuteElement : ConfigurationElement
	{
		[ConfigurationProperty("jobname", IsKey = true, IsRequired = true)]
		public string Name
		{
			get { return (string)this["jobname"]; }
			set { }
		}


		[ConfigurationProperty("class", IsRequired = true)]
		public string Type
		{
			get { return (string)this["class"]; }
			set { }
		}


		[ConfigurationProperty("method", IsRequired = true, DefaultValue = "execute")]
		public string Method
		{
			get { return (string)this["method"]; }
			set { }
		}

		[ConfigurationProperty("args", IsRequired = false, DefaultValue = "")]
		public string Args
		{
			get { return (string)this["args"]; }
			set { }
		}

		[ConfigurationProperty("expression", IsRequired = false, DefaultValue = "")]
		public string Expression
		{
			get { return (string)this["expression"]; }
			set { }
		}
	}
}
