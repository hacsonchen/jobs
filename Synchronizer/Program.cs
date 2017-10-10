using CommandLine;
using Synchronizer.Core;
using Synchronizer.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Synchronizer
{

	class Program
	{
		static string SERVICENAME = SyncApp.SERVICE_NAME;

		static int RunDebug(DebugOptions opts)
		{
			var service = ServiceManager.GetService(SERVICENAME);

			var instance = service.Container as WindowsService;

			ConsoleManager.Line(instance.APPID);

			if (SyncApp.start_time != null)
			{
				ConsoleManager.Line(SyncApp.start_time.Value.ToString("yyyyMMddHHmmss"));
			}
			else
			{
				ConsoleManager.Line("NULL");
			}

			return 1;
		}

		static int RunEntry(EntryOptions opts)
		{
			try
			{
				ServiceBase[] serviceToRun = new ServiceBase[] 
					{ 
						new WindowsService() 
					};

				ServiceBase.Run(serviceToRun);

				Logger.For("WindowService").Info("Windows Service Start");
				return 1;
			}
			catch (Exception ex)
			{
				Logger.For("WindowService").Error(ex);
				return 0;
			}
		}

		static int RunStart(StartOptions opts)
		{
			SyncApp.start_time = DateTime.Now;

			ConsoleManager.Line(SyncApp.start_time.Value.ToString("yyyyMMddHHmmss"));
			try
			{
				ServiceManager.Start(SERVICENAME);

				ConsoleManager.Line("启动成功");
			}
			catch (Exception ex)
			{
				Logger.For("Console").Error(ex);
				ConsoleManager.Line(ex.Message);
				ConsoleManager.Line(SyncApp.start_time.Value.ToString("yyyyMMddHHmmss"));

				return 0;
			}

			return 1;
		}

		static int RunStop(StopOptions opts)
		{
			ServiceManager.Stop(SERVICENAME);
			ConsoleManager.Line("停止成功");
			return 1;
		}

		static int RunInstall(InstallOptions opts)
		{
			try
			{
				ServiceManager.Install(SERVICENAME);
				return 1;
			}
			catch
			{
				ConsoleManager.Line("服务注册出现异常!!!");

				return 0;
			}

			
		}

		static int RunUnInstall(UnInstallOptions opts)
		{
			try
			{
				ServiceManager.Uninstall(SERVICENAME);
				return 1;
			}
			catch
			{
				ConsoleManager.Line("服务卸载出现异常!!!");

				return 0;
			}
		}
		static int Main(string[] args)
		{

#if DEBUG
			SyncApp.Start();
			return 1;
#else
			return CommandLine.Parser.Default.ParseArguments<StartOptions, StopOptions, InstallOptions,UnInstallOptions,DebugOptions,EntryOptions>(args)
			  .MapResult(
				(StartOptions opts) => RunStart(opts),
				(StopOptions opts) => RunStop(opts),
				(InstallOptions opts) => RunInstall(opts),
				(UnInstallOptions opts) => RunUnInstall(opts),
				(DebugOptions opts) => RunDebug(opts),
				(EntryOptions opts) => RunEntry(opts),
				errs => 1);
#endif


		}

		private static string ReadLines(string fileName, bool fromTop, int count)
		{
			var lines = File.ReadAllLines(fileName);
			if (fromTop)
			{
				return string.Join(Environment.NewLine, lines.Take(count));
			}
			return string.Join(Environment.NewLine, lines.Reverse().Take(count));
		}

		private static string ReadBytes(string fileName, bool fromTop, int count)
		{
			var bytes = File.ReadAllBytes(fileName);
			if (fromTop)
			{
				return Encoding.UTF8.GetString(bytes, 0, count);
			}
			return Encoding.UTF8.GetString(bytes, bytes.Length - count, count);
		}

		private static Tuple<string, string> MakeError()
		{
			return Tuple.Create("\0", "\0");
		}
	}
}
