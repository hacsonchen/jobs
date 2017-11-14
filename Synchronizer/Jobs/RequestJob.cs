using Quartz;
using Synchronizer.Core;
using Synchronizer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synchronizer.Jobs
{
    public class RequestJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            var map = context.JobDetail.JobDataMap;

            Logger.For("Request Job").Info(map);

            if ("GET".Equals(map.GetString("Type").ToUpper()))
            {
                try
                {
                    string response = HttpRequest.Get(map.GetString("Url"));
                    Logger.For("Request Job").Info(response);
                }
                catch (Exception ex)
                {
                    Logger.For("Request Job").Error(ex);
                }
            }
            else if ("POST".Equals(map.GetString("Type").ToUpper()))
            {
                try
                {
                    string response = HttpRequest.Post(map.GetString("Url"), map.GetString("Data"), map.GetString("DataType"));
                    Logger.For("Request Job").Info(response);
                }
                catch (Exception ex)
                {
                    Logger.For("Request Job").Error(ex);
                }
            }
        }
    }
}
