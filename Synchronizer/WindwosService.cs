using Synchronizer.Core;
using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Synchronizer
{
	public partial class WindowsService : ServiceBase
	{
		public string APPID = "XXXXXXXXXXXXXXXX";

		protected override void OnStart(string[] args)
		{
			SyncApp.Start();
		}

		protected override void OnStop()
		{
			SyncApp.Stop();
		}
	}
}
