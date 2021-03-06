﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using Jubilee.Core.Extensions;
using System.Threading.Tasks;

namespace Jubilee.Core.Runners
{
	public abstract class Runner : IRunner
	{
		protected dynamic parameters;
		public Runner()
		{
			parameters = new ExpandoObject();
		}
		public void Initialise(Dictionary<string, object> parameters)
		{
			this.parameters = parameters.ToExpando();
		}
		public void AddParameters(Dictionary<string, object> parameters)
		{
			foreach (var parameter in parameters)
			{
				AddParameter(parameter);
			}
		}
		public void AddParameter(string parameterName, object parameterValue)
		{
			AddParameter(new KeyValuePair<string, object>(parameterName, parameterValue));
		}
		public void AddParameter(KeyValuePair<string, object> parameter)
		{
			if (!((IDictionary<string, object>)this.parameters).ContainsKey(parameter.Key))
			{
				((IDictionary<string, object>)this.parameters).Add(parameter.Key, parameter.Value);
			}
			else
			{
				((IDictionary<string, object>)this.parameters)[parameter.Key] = parameter.Value;
			}
		}
		public abstract bool Run();
	}
}
