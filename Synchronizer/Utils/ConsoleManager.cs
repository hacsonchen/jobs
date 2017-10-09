using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synchronizer.Utils
{
	class ConsoleManager
	{
		public static void Welcome()
		{
			Console.WriteLine(" ------------- Synchronizer ------------- ");
		}

		public static void Line(string msg)
		{
			Console.WriteLine(string.Format(" {0}",msg));
		}

	}
}
