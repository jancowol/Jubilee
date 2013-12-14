﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using process = System.Diagnostics;
using Jubilee.Core.Notifications;
using Newtonsoft.Json;

namespace Jubilee.Core.Process.Plugins
{
	public class ScriptCSPlugin : Plugin
	{
		private INotificationService notificationService;
		public ScriptCSPlugin(INotificationService notificationService)
		{
			this.notificationService = notificationService;
		}
		public override bool Run()
		{
			process.Process process = new process.Process();
			process.StartInfo = new process.ProcessStartInfo("scriptcs", String.Format("-scriptname {0} -- {1}", parameters.ScriptName, String.Join(" ", ((IDictionary<string, object>)parameters).Select(x => x.Value))));
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.UseShellExecute = false;
			process.Start();
			process.WaitForExit();

			string errors = process.StandardError.ReadToEnd();
			string output = process.StandardOutput.ReadToEnd();
			notificationService.Notify("ScriptCS Output", output, NotificationType.Information);
			return true;
		}
	}
}