using System;
using System.Web.UI;

namespace LPG.Component
{
	public class CompressedStateFormatter : IStateFormatter
	{
		private IStateFormatter nextFormatter;

		public CompressedStateFormatter(IStateFormatter nextFormatter)
		{
			this.nextFormatter = nextFormatter;
		}

		public object Deserialize(string serializedState)
		{
			string empty = string.Empty;
			return this.nextFormatter.Deserialize(empty);
		}

		public string Serialize(object state)
		{
			this.nextFormatter.Serialize(state);
			return string.Empty;
		}
	}
}