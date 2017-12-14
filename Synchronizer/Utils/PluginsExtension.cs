using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Synchronizer.Utils
{
	public static class PluginsExtension
	{
		public static object InvokeMethod(this Type type, string method, object[] args)
		{
			MethodInfo mi = type.GetMethod(method, BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { }, null);
			string[] name = type.FullName.Split(',');
			
			ObjectHandle handle = Activator.CreateInstance(name[1], name[0]);
			Object obj = handle.Unwrap();
			return mi.Invoke(obj, args);
		}
	}
}
