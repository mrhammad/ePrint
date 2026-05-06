using System;
using System.Collections;
using System.Reflection;

public class GooglePolylines : CollectionBase
{
	public GooglePolyline this[int pIndex]
	{
		get
		{
			return (GooglePolyline)base.List[pIndex];
		}
		set
		{
			base.List[pIndex] = value;
		}
	}

	public GooglePolyline this[string pID]
	{
		get
		{
			for (int i = 0; i < base.Count; i++)
			{
				if (this[i].ID == pID)
				{
					return (GooglePolyline)base.List[i];
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

	public GooglePolylines()
	{
	}

	public void Add(GooglePolyline pPolyline)
	{
		base.List.Add(pPolyline);
	}

	public static GooglePolylines CloneMe(GooglePolylines prev)
	{
		GooglePolylines googlePolyline = new GooglePolylines();
		for (int i = 0; i < prev.Count; i++)
		{
			GooglePolyline googlePolyline1 = new GooglePolyline()
			{
				ColorCode = prev[i].ColorCode,
				Geodesic = prev[i].Geodesic,
				ID = prev[i].ID,
				Points = GooglePoints.CloneMe(prev[i].Points),
				Width = prev[i].Width
			};
			googlePolyline.Add(googlePolyline1);
		}
		return googlePolyline;
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