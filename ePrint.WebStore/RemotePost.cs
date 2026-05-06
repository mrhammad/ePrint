using System;
using System.Collections.Specialized;
using System.Web;

public class RemotePost
{
    private NameValueCollection Inputs = new NameValueCollection();

    public string Url = "";

    public string Method = "post";

    public string FormName = "form1";

    public RemotePost()
    {
    }

    public void Add(string name, string value)
    {
        this.Inputs.Add(name, value);
    }

    public void Post()
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.Write("<html><head>");
        HttpContext.Current.Response.Write(string.Format("</head><body onload=\"document.{0}.submit()\">", this.FormName));
        HttpContext.Current.Response.Write(string.Format("<form name=\"{0}\" method=\"{1}\" action=\"{2}\" >", this.FormName, this.Method, this.Url));
        for (int i = 0; i < this.Inputs.Keys.Count; i++)
        {
            HttpContext.Current.Response.Write(string.Format("<input name=\"{0}\" type=\"hidden\" value=\"{1}\">", this.Inputs.Keys[i], this.Inputs[this.Inputs.Keys[i]]));
        }
        HttpContext.Current.Response.Write("</form>");
        HttpContext.Current.Response.Write("</body></html>");
        HttpContext.Current.Response.End();
    }
}