using System;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Telerik.Web.SessionDS
{
	public class SessionDataSource : SqlDataSource
	{
		[DefaultValue("")]
		[Description("Reset the session field on initial load.")]
		[NotifyParentProperty(true)]
		public bool ClearSessionOnInitialLoad
		{
			get
			{
				object item = this.ViewState["ClearSessionOnInitialLoad"];
				if (item == null)
				{
					item = true;
				}
				return (bool)item;
			}
			set
			{
				this.ViewState["ClearSessionOnInitialLoad"] = value;
			}
		}

		public string DataSourceSessionKey
		{
			get
			{
				return this.SessionKey;
			}
		}

		[DefaultValue(true)]
		[Description("Displays a warning that that the modifications will not be persisted.")]
		public bool DisplayWarning
		{
			get
			{
				object item = this.ViewState["displayWarning"];
				if (item == null)
				{
					item = true;
				}
				return (bool)item;
			}
			set
			{
				this.ViewState["displayWarning"] = value;
			}
		}

		[DefaultValue("")]
		[Description("Comma delimited list of primary key fields (32-bit integers only).")]
		[NotifyParentProperty(true)]
		public string PrimaryKeyFields
		{
			get
			{
				object item = this.ViewState["pkFields"];
				if (item == null)
				{
					item = string.Empty;
				}
				return (string)item;
			}
			set
			{
				this.ViewState["pkFields"] = value;
			}
		}

		[DefaultValue(false)]
		public bool RevertToOriginalDataSource
		{
			get
			{
				if (this.ViewState["_rtods"] == null)
				{
					return false;
				}
				return (bool)this.ViewState["_rtods"];
			}
			set
			{
				this.ViewState["_rtods"] = value;
			}
		}

		public string SessionKey
		{
			get
			{
				return (string)this.ViewState["SessionKey"] ?? string.Concat(this.Page.ToString(), "_", this.ID);
			}
			set
			{
				this.ViewState["SessionKey"] = value;
			}
		}

		[DefaultValue(true)]
		public override bool Visible
		{
			get
			{
				return true;
			}
			set
			{
				base.Visible = value;
			}
		}

		public SessionDataSource()
		{
		}

		public void ClearSessionData()
		{
			this.Context.Session[this.DataSourceSessionKey] = null;
		}

		protected override SqlDataSourceView CreateDataSourceView(string viewName)
		{
			if (base.DesignMode)
			{
				return base.CreateDataSourceView(viewName);
			}
			return new SessionDataSourceView(this, viewName, this.Context, base.CreateDataSourceView(viewName), this.Context.Session);
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			if (!base.DesignMode && !this.Page.IsPostBack && this.ClearSessionOnInitialLoad)
			{
				this.Context.Session[this.DataSourceSessionKey] = null;
			}
		}

		protected override void Render(HtmlTextWriter writer)
		{
			base.Render(writer);
			if (!this.RevertToOriginalDataSource && this.DisplayWarning)
			{
				writer.AddAttribute("style", "color:maroon;");
				writer.RenderBeginTag(HtmlTextWriterTag.Div);
				writer.Write("Note: The changes in the data will be persisted per Session only. The data will be reset next time you visit the page.");
				writer.RenderEndTag();
			}
		}
	}
}