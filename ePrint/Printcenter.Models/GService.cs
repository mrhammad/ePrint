using System;
using System.Collections;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;

[ScriptService]
[WebService(Namespace="http://tempuri.org/")]
[WebServiceBinding(ConformsTo=WsiProfiles.BasicProfile1_1)]
public class GService : WebService
{
	public GService()
	{
	}

	[WebMethod(EnableSession=true)]
	public GoogleObject GetGoogleObject()
	{
		GoogleObject item = (GoogleObject)HttpContext.Current.Session["GOOGLE_MAP_OBJECT"];
		HttpContext.Current.Session["GOOGLE_MAP_OBJECT_OLD"] = new GoogleObject(item);
		return item;
	}

	[WebMethod(EnableSession=true)]
	public GoogleObject GetOptimizedGoogleObject()
	{
		GoogleObject item = (GoogleObject)HttpContext.Current.Session["GOOGLE_MAP_OBJECT"];
		GoogleObject googleObject = (GoogleObject)HttpContext.Current.Session["GOOGLE_MAP_OBJECT_OLD"];
		GoogleObject centerPoint = new GoogleObject();
		if (googleObject != null)
		{
			for (int i = 0; i < item.Points.Count; i++)
			{
				string str = "";
				GooglePoint googlePoint = item.Points[i];
				GooglePoint item1 = googleObject.Points[googlePoint.ID];
				if (item1 != null)
				{
					if (!item1.Equals(googlePoint))
					{
						str = "C";
					}
					googleObject.Points.Remove(item1.ID);
				}
				else
				{
					str = "N";
				}
				if (str != "")
				{
					googlePoint.PointStatus = str;
					centerPoint.Points.Add(googlePoint);
				}
			}
			for (int j = 0; j < googleObject.Points.Count; j++)
			{
				GooglePoint googlePoint1 = googleObject.Points[j];
				googlePoint1.PointStatus = "D";
				centerPoint.Points.Add(googlePoint1);
			}
			for (int k = 0; k < item.Polylines.Count; k++)
			{
				string str1 = "";
				GooglePolyline googlePolyline = item.Polylines[k];
				GooglePolyline googlePolyline1 = googleObject.Polylines[googlePolyline.ID];
				if (googlePolyline1 != null)
				{
					if (!googlePolyline1.Equals(googlePolyline))
					{
						str1 = "C";
					}
					googleObject.Polylines.Remove(googlePolyline1.ID);
				}
				else
				{
					str1 = "N";
				}
				if (str1 != "")
				{
					googlePolyline.LineStatus = str1;
					centerPoint.Polylines.Add(googlePolyline);
				}
			}
			for (int l = 0; l < googleObject.Polylines.Count; l++)
			{
				GooglePolyline item2 = googleObject.Polylines[l];
				item2.LineStatus = "D";
				centerPoint.Polylines.Add(item2);
			}
			for (int m = 0; m < item.Polygons.Count; m++)
			{
				string str2 = "";
				GooglePolygon googlePolygon = item.Polygons[m];
				GooglePolygon googlePolygon1 = googleObject.Polygons[googlePolygon.ID];
				if (googlePolygon1 != null)
				{
					if (!googlePolygon1.Equals(googlePolygon))
					{
						str2 = "C";
					}
					googleObject.Polygons.Remove(googlePolygon1.ID);
				}
				else
				{
					str2 = "N";
				}
				if (str2 != "")
				{
					googlePolygon.Status = str2;
					centerPoint.Polygons.Add(googlePolygon);
				}
			}
			for (int n = 0; n < googleObject.Polygons.Count; n++)
			{
				GooglePolygon googlePolygon2 = googleObject.Polygons[n];
				googlePolygon2.Status = "D";
				centerPoint.Polygons.Add(googlePolygon2);
			}
		}
		centerPoint.CenterPoint = item.CenterPoint;
		centerPoint.ZoomLevel = item.ZoomLevel;
		centerPoint.ShowTraffic = item.ShowTraffic;
		centerPoint.RecenterMap = item.RecenterMap;
		centerPoint.MapType = item.MapType;
		centerPoint.AutomaticBoundaryAndZoom = item.AutomaticBoundaryAndZoom;
		HttpContext.Current.Session["GOOGLE_MAP_OBJECT_OLD"] = new GoogleObject(item);
		return centerPoint;
	}

	[WebMethod(EnableSession=true)]
	public void RecenterMapComplete()
	{
		GoogleObject item = (GoogleObject)HttpContext.Current.Session["GOOGLE_MAP_OBJECT"];
		GoogleObject googleObject = (GoogleObject)HttpContext.Current.Session["GOOGLE_MAP_OBJECT_OLD"];
		item.RecenterMap = false;
		googleObject.RecenterMap = false;
	}

	[WebMethod(EnableSession=true)]
	public void SetLatLon(string pID, double pLatitude, double pLongitude)
	{
		GoogleObject item = (GoogleObject)HttpContext.Current.Session["GOOGLE_MAP_OBJECT"];
		GoogleObject googleObject = (GoogleObject)HttpContext.Current.Session["GOOGLE_MAP_OBJECT_OLD"];
		item.Points[pID].Latitude = pLatitude;
		item.Points[pID].Longitude = pLongitude;
		googleObject.Points[pID].Latitude = pLatitude;
		googleObject.Points[pID].Longitude = pLongitude;
	}

	[WebMethod(EnableSession=true)]
	public void SetZoom(string pID, int pZoomLevel)
	{
		GoogleObject item = (GoogleObject)HttpContext.Current.Session["GOOGLE_MAP_OBJECT"];
		GoogleObject googleObject = (GoogleObject)HttpContext.Current.Session["GOOGLE_MAP_OBJECT_OLD"];
		item.ZoomLevel = pZoomLevel;
		googleObject.ZoomLevel = pZoomLevel;
	}
}