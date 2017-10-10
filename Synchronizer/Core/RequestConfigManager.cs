using Synchronizer.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synchronizer.Core
{
	public class RequestConfigManager : IConfigManager
	{
		private readonly IDictionary<string, object> Values = new Dictionary<string,object>
        {
        };

		public RequestConfigManager(RequestElement config)
		{
			Values.Add("JobName",config.Name);
			Values.Add("Url", config.Url);
			Values.Add("Type", config.Type);
			Values.Add("DataType", config.DataType);
			Values.Add("Expression", config.Expression);
			Values.Add("Data", config.Data);
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
