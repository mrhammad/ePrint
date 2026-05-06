using System;
using System.Data.SqlClient;

public class Employee
{
	private int _EmployeeID;

	private string _LastName;

	private string _FirstName;

	private string _Title;

	private string _TitleOfCourtesy;

	private DateTime? _BirthDate;

	private string _Notes;

	public DateTime? BirthDate
	{
		get
		{
			return this._BirthDate;
		}
		set
		{
			bool flag;
			DateTime? nullable = this._BirthDate;
			DateTime? nullable1 = value;
			if (nullable.HasValue != nullable1.HasValue)
			{
				flag = true;
			}
			else
			{
				flag = (!nullable.HasValue ? false : nullable.GetValueOrDefault() != nullable1.GetValueOrDefault());
			}
			if (flag)
			{
				this._BirthDate = value;
			}
		}
	}

	public int EmployeeID
	{
		get
		{
			return this._EmployeeID;
		}
		set
		{
			if (this._EmployeeID != value)
			{
				this._EmployeeID = value;
			}
		}
	}

	public string FirstName
	{
		get
		{
			return this._FirstName;
		}
		set
		{
			if (this._FirstName != value)
			{
				this._FirstName = value;
			}
		}
	}

	public string LastName
	{
		get
		{
			return this._LastName;
		}
		set
		{
			if (this._LastName != value)
			{
				this._LastName = value;
			}
		}
	}

	public string Notes
	{
		get
		{
			return this._Notes;
		}
		set
		{
			if (this._Notes != value)
			{
				this._Notes = value;
			}
		}
	}

	public string Title
	{
		get
		{
			return this._Title;
		}
		set
		{
			if (this._Title != value)
			{
				this._Title = value;
			}
		}
	}

	public string TitleOfCourtesy
	{
		get
		{
			return this._TitleOfCourtesy;
		}
		set
		{
			if (this._TitleOfCourtesy != value)
			{
				this._TitleOfCourtesy = value;
			}
		}
	}

	public Employee()
	{
	}

	public Employee(SqlDataReader reader)
	{
		this._EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
		this._LastName = reader["LastName"].ToString();
		this._FirstName = reader["FirstName"].ToString();
		this._Title = reader["Title"].ToString();
		this._TitleOfCourtesy = reader["TitleOfCourtesy"].ToString();
		this._BirthDate = new DateTime?(Convert.ToDateTime(reader["BirthDate"]));
		this._Notes = reader["Notes"].ToString();
	}
}