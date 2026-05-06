using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;

public class UnitConverter : JavaScriptConverter
{
	public override IEnumerable<Type> SupportedTypes
	{
		get
		{
			return new ReadOnlyCollection<Type>(new List<Type>(new Type[] { typeof(Unit) }));
		}
	}

	public UnitConverter()
	{
	}

	public override object Deserialize(IDictionary<string, object> dictionary, Type type, JavaScriptSerializer serializer)
	{
		if (dictionary == null)
		{
			throw new ArgumentNullException("dictionary");
		}
		if (!object.ReferenceEquals(type, typeof(Unit)) || dictionary.Count <= 0)
		{
			return null;
		}
		if ((bool)dictionary["IsEmpty"])
		{
			return Unit.Empty;
		}
		double num = Convert.ToDouble(dictionary["Value"]);
		UnitType unitType = (UnitType)Enum.Parse(typeof(UnitType), dictionary["Type"].ToString());
		return new Unit(num, unitType);
	}

	public override IDictionary<string, object> Serialize(object obj, JavaScriptSerializer serializer)
	{
		Unit unit = (Unit)obj;
		Dictionary<string, object> strs = new Dictionary<string, object>()
		{
			{ "Type", unit.Type },
			{ "Value", unit.Value },
			{ "IsEmpty", unit.IsEmpty }
		};
		return strs;
	}
}