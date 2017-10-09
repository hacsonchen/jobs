using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synchronizer.Core
{
	public interface IConfigManager
	{
		string GetValue(string key);
	}
}
