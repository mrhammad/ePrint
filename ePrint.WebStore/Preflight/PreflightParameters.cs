using System;

namespace Preflight
{
	public class PreflightParameters
	{
		private string _correctedFile;

		private string _reportFile;

		private bool _isPreflighted;

		public string CorrectedFile
		{
			get
			{
				return this._correctedFile;
			}
			set
			{
				this._correctedFile = value;
			}
		}

		public bool IsPreflighted
		{
			get
			{
				return this._isPreflighted;
			}
			set
			{
				this._isPreflighted = value;
			}
		}

		public string ReportFile
		{
			get
			{
				return this._reportFile;
			}
			set
			{
				this._reportFile = value;
			}
		}

		public PreflightParameters()
		{
		}
	}
}