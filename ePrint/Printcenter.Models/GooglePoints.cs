using System;
using System.Collections;
using System.Reflection;

public class GooglePoints : CollectionBase
{
	public GooglePoint this[int pIndex]
	{
		get
		{
			return (GooglePoint)base.List[pIndex];
		}
		set
		{
			base.List[pIndex] = value;
		}
	}

	public GooglePoint this[string pID]
	{
		get
		{
			for (int i = 0; i < base.Count; i++)
			{
				if (this[i].ID == pID)
				{
					return (GooglePoint)base.List[i];
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

	public GooglePoints()
	{
	}

	public void Add(GooglePoint pPoint)
	{
		base.List.Add(pPoint);
	}

	public static GooglePoints CloneMe(GooglePoints prev)
	{
		GooglePoints googlePoint = new GooglePoints();
		for (int i = 0; i < prev.Count; i++)
		{
			googlePoint.Add(new GooglePoint(prev[i].ID, prev[i].Latitude, prev[i].Longitude, prev[i].IconImage, prev[i].InfoHTML, prev[i].ToolTip, prev[i].Draggable));
		}
		return googlePoint;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		GooglePoints googlePoint = obj as GooglePoints;
		if (googlePoint == null)
		{
			return false;
		}
		if (googlePoint.Count != base.Count)
		{
			return false;
		}
		for (int i = 0; i < googlePoint.Count; i++)
		{
			if (!this[i].Equals(googlePoint[i]))
			{
				return false;
			}
		}
		return true;
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