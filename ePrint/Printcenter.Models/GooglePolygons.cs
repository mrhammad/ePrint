using System;
using System.Collections;
using System.Reflection;

public class GooglePolygons : CollectionBase
{
	public GooglePolygon this[int pIndex]
	{
		get
		{
			return (GooglePolygon)base.List[pIndex];
		}
		set
		{
			base.List[pIndex] = value;
		}
	}

	public GooglePolygon this[string pID]
	{
		get
		{
			for (int i = 0; i < base.Count; i++)
			{
				if (this[i].ID == pID)
				{
					return (GooglePolygon)base.List[i];
				}
			}
			return null;
		}
		set
		{
			for (int i = 0; i < base.Count; i++)
			{
				if (this[i].ID == pID)
				{
					base.List[i] = value;
				}
			}
		}
	}

	public GooglePolygons()
	{
	}

	public void Add(GooglePolygon pPolygon)
	{
		base.List.Add(pPolygon);
	}

	public static GooglePolygons CloneMe(GooglePolygons prev)
	{
		GooglePolygons googlePolygon = new GooglePolygons();
		for (int i = 0; i < prev.Count; i++)
		{
			GooglePolygon googlePolygon1 = new GooglePolygon()
			{
				FillColor = prev[i].FillColor,
				FillOpacity = prev[i].FillOpacity,
				ID = prev[i].ID,
				Status = prev[i].Status,
				StrokeColor = prev[i].StrokeColor,
				StrokeOpacity = prev[i].StrokeOpacity,
				StrokeWeight = prev[i].StrokeWeight,
				Points = GooglePoints.CloneMe(prev[i].Points)
			};
			googlePolygon.Add(googlePolygon1);
		}
		return googlePolygon;
	}

	public void Remove(int pIndex)
	{
		base.RemoveAt(pIndex);
	}

	public void Remove(string pID)
	{
		for (int i = 0; i < base.Count; i++)
		{
			if (this[i].ID == pID)
			{
				base.List.RemoveAt(i);
				return;
			}
		}
	}
}