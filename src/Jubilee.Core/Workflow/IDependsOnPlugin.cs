﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jubilee.Core.Plugins
{
	public interface IDependsOnPlugin<Plugin> where Plugin : IPlugin
	{
	}
}
