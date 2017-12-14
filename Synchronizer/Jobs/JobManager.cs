using Quartz;
using Quartz.Impl;
using Quartz.Impl.Triggers;
using Synchronizer.Configuration;
using Synchronizer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synchronizer.Jobs
{
	public static class JobManager
	{

		public static void AddJob<T>(this IScheduler scheduler, string jobName, string expression)
		{

			scheduler.ScheduleJob(
			new JobDetailImpl(jobName, typeof(T)),
			TriggerBuilder.Create().StartNow().WithCronSchedule(expression).Build());
		}

		public static void AddJob(this IScheduler scheduler, RequestElementCollection collection)
		{
			foreach (RequestElement element in collection)
			{
				RequestConfigManager config = new RequestConfigManager(element);
				JobDataMap map = new JobDataMap(config.ToMap());

				scheduler.ScheduleJob(
				JobBuilder.Create<RequestJob>().WithIdentity(element.Name).SetJobData(map).Build(),
				TriggerBuilder.Create().StartNow().WithCronSchedule(element.Expression).Build());
			}
		}

		public static void AddJob(this IScheduler scheduler, ExecuteElementCollection collection)
		{
			foreach (ExecuteElement element in collection)
			{
				ExecuteConfigManager config = new ExecuteConfigManager(element);
				JobDataMap map = new JobDataMap(config.ToMap());

				scheduler.ScheduleJob(
				JobBuilder.Create<ExecuteJob>().WithIdentity(element.Name).SetJobData(map).Build(),
				TriggerBuilder.Create().StartNow().WithCronSchedule(element.Expression).Build());
			}
		}


	}
}
