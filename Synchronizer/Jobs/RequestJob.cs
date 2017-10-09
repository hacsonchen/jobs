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
				HttpRequest.Get(map.GetString("Url"));
			}
		}
	}
}
