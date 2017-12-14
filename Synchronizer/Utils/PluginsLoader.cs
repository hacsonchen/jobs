using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Synchronizer.Utils
{
	public class PluginsLoader
	{
		private static string dir = "plugins\\";
		IDictionary<string, Assembly> TYPE_CACHE = new Dictionary<string, Assembly>();
		string PluginsDir = System.AppDomain.CurrentDomain.BaseDirectory + dir;



		public void Load(string type)
		{
			string[] names = type.Split(',');
			string dllname = names[1].Trim().ToUpper();
#if DEBUG
			Logger.For("DEBUG").Debug(PluginsDir);
#endif
			

			if (!TYPE_CACHE.ContainsKey(dllname))
			{
#if DEBUG
				Logger.For("DEBUG").Debug("加载类库路径：" + PluginsDir + names[1].Trim() + ".dll");
#endif
				Assembly assembly = Assembly.LoadFile(PluginsDir + names[1].Trim() + ".dll");

				Logger.For("PLUGINS").Info("加载[" + dllname + "]成功");
				TYPE_CACHE.Add(dllname, assembly);
			}
		}

	 

		public Type GetType(string type)
		{
			string[] names = type.Split(',');
			return GetAssembly(type).GetType(names[0]);
		}

		public Assembly GetAssembly(string type)
		{
			string[] names = type.Split(',');
			string dllname = names[1].Trim().ToUpper();
			Assembly assembly;
			TYPE_CACHE.TryGetValue(dllname, out assembly);

			return assembly;
		}

		public object InvokeMethod(string clazz, string method, object[] args)
		{
			string[] names = clazz.Split(',');
			Assembly assembly = GetAssembly(clazz);
			Type type = assembly.GetType(names[0]);
			object obj = assembly.CreateInstance(names[0]);
			MethodInfo mi = type.GetMethod(method, BindingFlags.Public | BindingFlags.Instance);
			return mi.Invoke(obj, args);
		}


	}
}
