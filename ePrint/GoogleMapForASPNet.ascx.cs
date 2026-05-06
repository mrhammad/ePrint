using System;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePrint
{
    public partial class GoogleMapForASPNet : System.Web.UI.UserControl
    {
        //protected ScriptManagerProxy ScriptManager1;

        //protected HiddenField hidEventName;

        //protected HiddenField hidEventValue;

        //protected UpdatePanel UpdatePanelXXXYYY;

        private GoogleObject _googlemapobject = new GoogleObject();

        private bool _showcontrols;

        protected Global ApplicationInstance
        {
            get
            {
                return (Global)this.Context.ApplicationInstance;
            }
        }

        public GoogleObject GoogleMapObject
        {
            get
            {
                return this._googlemapobject;
            }
            set
            {
                this._googlemapobject = value;
            }
        }

        protected DefaultProfile Profile
        {
            get
            {
                return (DefaultProfile)this.Context.Profile;
            }
        }

        public bool ShowControls
        {
            get
            {
                return this._showcontrols;
            }
            set
            {
                this._showcontrols = value;
            }
        }

        public GoogleMapForASPNet()
        {
        }

        public void OnMapClicked(double dLatitude, double dLongitude)
        {
            if (this.MapClicked != null)
            {
                this.GoogleMapObject = (GoogleObject)HttpContext.Current.Session["GOOGLE_MAP_OBJECT"];
                this.MapClicked(dLatitude, dLongitude);
            }
        }

        public void OnPushpinClicked(string pID)
        {
            if (this.PushpinClicked != null)
            {
                this.GoogleMapObject = (GoogleObject)HttpContext.Current.Session["GOOGLE_MAP_OBJECT"];
                this.PushpinClicked(pID);
            }
        }

        public void OnPushpinDrag(string pID)
        {
            if (this.PushpinDrag != null)
            {
                this.GoogleMapObject = (GoogleObject)HttpContext.Current.Session["GOOGLE_MAP_OBJECT"];
                this.PushpinDrag(pID);
            }
        }

        public void OnZoomChanged(int pZoomLevel)
        {
            if (this.ZoomChanged != null)
            {
                this.GoogleMapObject = (GoogleObject)HttpContext.Current.Session["GOOGLE_MAP_OBJECT"];
                this.ZoomChanged(pZoomLevel);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.hidEventName.Value == "MapClicked")
            {
                string value = this.hidEventValue.Value;
                char[] chrArray = new char[] { ',' };
                string[] strArrays = value.Split(chrArray, StringSplitOptions.None);
                if ((int)strArrays.Length > 0)
                {
                    double num = double.Parse(strArrays[0]);
                    double num1 = double.Parse(strArrays[1]);
                    this.hidEventName.Value = "";
                    this.OnMapClicked(num, num1);
                }
            }
            if (this.hidEventName.Value == "PushpinClicked")
            {
                this.hidEventName.Value = "";
                this.OnPushpinClicked(this.hidEventValue.Value);
            }
            if (this.hidEventName.Value == "PushpinDrag")
            {
                this.hidEventName.Value = "";
                this.OnPushpinDrag(this.hidEventValue.Value);
            }
            if (this.hidEventName.Value == "ZoomChanged")
            {
                this.hidEventName.Value = "";
                this.OnZoomChanged(int.Parse(this.hidEventValue.Value));
            }
            if (base.IsPostBack)
            {
                this.GoogleMapObject = (GoogleObject)base.Session["GOOGLE_MAP_OBJECT"];
                if (this.GoogleMapObject == null)
                {
                    this.GoogleMapObject = new GoogleObject();
                    base.Session["GOOGLE_MAP_OBJECT"] = this.GoogleMapObject;
                }
            }
            else
            {
                base.Session["GOOGLE_MAP_OBJECT"] = this.GoogleMapObject;
            }
            string str = string.Concat("<script type='text/javascript' src='https://maps.googleapis.com/maps/api/js?key=", this.GoogleMapObject.APIKey, "&sensor=false'></script>");
            str = string.Concat(str, "<script type='text/javascript' src='GoogleMapAPIWrapper.js'></script>");
            str = string.Concat(str, "<script language='javascript'> if (window.DrawGoogleMap) { DrawGoogleMap(); } </script>");
            this.Page.ClientScript.RegisterStartupScript(this.Page.GetType(), "onLoadCall", str);
        }

        public event GoogleMapForASPNet.MapClickedHandler MapClicked;

        public event GoogleMapForASPNet.PushpinClickedHandler PushpinClicked;

        public event GoogleMapForASPNet.PushpinDragHandler PushpinDrag;

        public event GoogleMapForASPNet.ZoomChangedHandler ZoomChanged;

        public delegate void MapClickedHandler(double dLatitude, double dLongitude);

        public delegate void PushpinClickedHandler(string pID);

        public delegate void PushpinDragHandler(string pID);

        public delegate void ZoomChangedHandler(int pZoomLevel);
    }
}