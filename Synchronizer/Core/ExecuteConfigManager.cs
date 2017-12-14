using Synchronizer.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synchronizer.Core
{
	public class ExecuteConfigManager : IConfigManager
	{
		private readonly IDictionary<string, object> Values = new Dictionary<string, object>
		{
		};

		public ExecuteConfigManager(ExecuteElement config)
		{
			Values.Add("JobName", config.Name);
			Values.Add("Type", config.Type);
			Values.Add("Method", config.Method);
			Values.Add("Args", config.Args);
			Values.Add("Expression", config.Expression);
		}

		public IDictionary<string, object> ToMap()
		{
			return Values;
		}


		public string GetValue(string key)
		{
			object value;

			if (Values.TryGetValue(key, out value))
			{
				return (string)value;
			}

			return "Key not found!";
		}
	}
}
