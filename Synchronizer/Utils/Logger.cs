using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synchronizer.Utils
{
	static class Logger
	{
		public static ILog For(string name)
		{
			return log4net.LogManager.GetLogger(name);
		}
		
	}
}
