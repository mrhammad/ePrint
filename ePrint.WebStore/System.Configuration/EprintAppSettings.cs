using System;
using System.Collections.Generic;
using System.Reflection;

namespace System.Configuration
{
	public class EprintAppSettings
	{
		private Dictionary<string, string> settings;

		public string this[string key]
		{
			get
			{
				if (!this.settings.ContainsKey(key))
				{
					return null;
				}
				return this.settings[key];
			}
		}

		public EprintAppSettings(Dictionary<string, string> settings)
		{
			this.settings = settings;
		}
	}
}