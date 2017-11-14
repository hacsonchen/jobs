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

        public static void AddJob(this IScheduler scheduler, JobElementCollection collection)
        {
            foreach (JobElement element in collection)
            {
                if (element.RequestJobs.Count > 0)
                {
                    foreach (var request in element.RequestJobs)
                    {
                        AddRequestJob(scheduler, element, request);
                    }

                }
                else if(!string.IsNullOrWhiteSpace(element.RequestJobs.Url))
                {
                    AddRequestJob(scheduler, element, new RequestElement
                    {
                        Url = element.RequestJobs.Url,
                        Type = element.RequestJobs.Type,
                        DataType = element.RequestJobs.DataType,
                        Data = element.RequestJobs.Data
                    });
                }
            }
        }

        private static void AddRequestJob(IScheduler scheduler, JobElement job, RequestElement request)
        {
            RequestConfigManager config = new RequestConfigManager(request);
            JobDataMap map = new JobDataMap(config.ToMap());

            scheduler.ScheduleJob(
            JobBuilder.Create<RequestJob>().WithIdentity(job.Name).SetJobData(map).Build(),
            TriggerBuilder.Create().StartNow().WithCronSchedule(job.Expression).Build());
        }


    }
}
