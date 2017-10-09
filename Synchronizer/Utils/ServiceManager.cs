using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Synchronizer.Utils
{
	public class ServiceManager
	{
		/// <summary>
		/// 服务是否存在
		/// </summary>
		/// <param name="serviceName"></param>
		/// <returns></returns>
		public static bool IsExisted(string serviceName)
		{
			ServiceController service = GetService(serviceName);

			if (service == null)
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		public static ServiceController GetService(string serviceName)
		{
			ServiceController[] services = ServiceController.GetServices();
			foreach (ServiceController s in services)
			{
				if (s.ServiceName == serviceName)
				{
					return s;
				}
			}

			return null;
		}

		/// <summary>
		/// 启动服务
		/// </summary>
		/// <param name="serviceName"></param>
		public static void Start(string serviceName)
		{
			if (IsExisted(serviceName))
			{
				System.ServiceProcess.ServiceController service = new System.ServiceProcess.ServiceController(serviceName);
				if (service.Status != System.ServiceProcess.ServiceControllerStatus.Running &&
					service.Status != System.ServiceProcess.ServiceControllerStatus.StartPending)
				{
					service.Start();

					service.WaitForStatus(System.ServiceProcess.ServiceControllerStatus.Running, new TimeSpan(10000000 * 60));
				}
			}
		}

		public static void Stop(string serviceName)
		{
			if (IsExisted(serviceName))
			{
				System.ServiceProcess.ServiceController service = new System.ServiceProcess.ServiceController(serviceName);
				if (service.Status == System.ServiceProcess.ServiceControllerStatus.Running ||
					service.Status == System.ServiceProcess.ServiceControllerStatus.StartPending)
				{
					if (service.CanStop)
					{
						service.Stop();
					}
					else
					{
						throw new ApplicationException("服务不能停止");
					}
				}
			}
		}

		/// <summary>
		/// 获取服务状态
		/// </summary>
		/// <param name="serviceName"></param>
		/// <returns></returns>
		public static ServiceControllerStatus GetStatus(string serviceName)
		{
			System.ServiceProcess.ServiceController service = new System.ServiceProcess.ServiceController(serviceName);
			return service.Status;
		}

		public static void Install(string serviceName, string displayName = null, string description = null)
		{
			TransactedInstaller ti = new TransactedInstaller();
			ti.Installers.Add(new ServiceProcessInstaller
			{
				Account = ServiceAccount.LocalSystem
			});

			ti.Installers.Add(new ServiceInstaller
			{
				DisplayName = displayName ?? serviceName,
				ServiceName = serviceName,
				Description = description ?? serviceName,
				StartType = ServiceStartMode.Automatic
			});

			ti.Context = new InstallContext();
			ti.Context.Parameters["assemblypath"] = "\"" + Assembly.GetEntryAssembly().Location + "\" entry ";

			ti.Install(new Hashtable());

		}

		public static void Uninstall(string serviceName)
		{
			TransactedInstaller ti = new TransactedInstaller();
			ti.Installers.Add(new ServiceProcessInstaller
			{
				Account = ServiceAccount.LocalSystem
			});

			ti.Installers.Add(new ServiceInstaller
			{
				DisplayName = serviceName,
				ServiceName = serviceName,
				Description = "Synchronizer",
				StartType = ServiceStartMode.Automatic
			});

			ti.Context = new InstallContext();
			ti.Context.Parameters["assemblypath"] = "\"" + Assembly.GetEntryAssembly().Location + "\" /service";

			ti.Uninstall(null);
		}
	}
}
