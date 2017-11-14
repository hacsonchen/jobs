using Quartz;
using Synchronizer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synchronizer.Jobs
{
    public class AssemblyJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            var map = context.JobDetail.JobDataMap;

            Logger.For("Assembly Job").Info(map);

            
        }
    }
}
