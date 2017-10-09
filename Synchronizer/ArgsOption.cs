using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synchronizer
{

	interface IOptions
	{

	}

	[Verb("entry", HelpText = "Entry Of Windows Service.(Do Not Call this verb via manual)")]
	class EntryOptions : IOptions
	{

	}

	[Verb("debug", HelpText = "")]
	class DebugOptions : IOptions
	{

	}

	[Verb("start", HelpText = "Start Host Service.")]
	class StartOptions : IOptions
	{

	}

	[Verb("status", HelpText = "Check Service Status.")]
	class StatusOptions : IOptions
	{

	}

	[Verb("stop", HelpText = "Stop Host Service.")]
	class StopOptions : IOptions
	{

	}

	[Verb("install", HelpText = "Install Host Service.")]
	class InstallOptions : IOptions
	{

	}

	[Verb("uninstall", HelpText = "Uninstall Host Service.")]
	class UnInstallOptions : IOptions
	{

	}
}
