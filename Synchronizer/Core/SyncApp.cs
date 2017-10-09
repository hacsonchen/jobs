using Microsoft.Practices.Unity;
using Quartz;
using Quartz.Unity;
using Synchronizer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Synchronizer.Jobs;

namespace Synchronizer.Core
{
	public class SyncApp
	{
		private static UnityContainer container;

		public static DateTime? start_time;

		public static string SERVICE_NAME = "ShuJuPingTai-GCI";

		public static void Start()
		{
			container = new UnityContainer();

			Logger.For("Console").Info(" Registering types in Unity container...");

			container.AddNewExtension<QuartzUnityExtension>();

			Logger.For("Console").Info(" Resolving IScheduler instance...");

			var scheduler = container.Resolve<IScheduler>();

			Logger.For("Console").Info(" Reading Configuration...");

			Logger.For("Console").Info(" Scheduling job...");

			try
			{
				var requestJobs = AppConfigurationManager.Jobs.RequestJobs;
				scheduler.AddJob(requestJobs);

				Logger.For("Console").Info(" Starting scheduler...");

				scheduler.Start();
			}
			catch (Exception ex)
			{
				Logger.For("Console").Error(ex);
			}
		}

		public static string[] Jobs()
		{
			var scheduler = container.Resolve<IScheduler>();

			var groupNames = scheduler.GetJobGroupNames();

			foreach (string groupName in groupNames)
			{
				
			}


			return null;
		}

		public static void Stop()
		{
			var scheduler = container.Resolve<IScheduler>();

			Logger.For("Console").Info(" Stopping scheduler...");

			scheduler.Shutdown();
		}
	}
}
