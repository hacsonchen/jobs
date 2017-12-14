using Quartz;
using Synchronizer.Core;
using Synchronizer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Synchronizer.Jobs
{
	public class ExecuteJob : IJob
	{
		public void Execute(IJobExecutionContext context)
		{
			var map = context.JobDetail.JobDataMap;

			Logger.For("EXECUTE-JOB 参数").Info(map);

			//Type type = SyncApp.plugins.GetType(map.GetString("Type"));
			//Type type = Type.GetType(map.GetString("Type"));
			try
			{
				object results = SyncApp.plugins.InvokeMethod(map.GetString("Type"), map.GetString("Method"), null);

				Logger.For("EXECUTE-JOB 参数").Info(map);
				Logger.For("EXECUTE-JOB 结果").Info(results);
			}
			catch (Exception ex)
			{
				Logger.For("EXECUTE-JOB").Error(ex);
			}

		}
	}
}
