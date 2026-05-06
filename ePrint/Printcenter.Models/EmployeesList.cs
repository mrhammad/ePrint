using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public class EmployeesList : List<Employee>
{
	public EmployeesList()
	{
		this.LoadAllEmployees();
	}

	public Employee GetEmployeeByEmployeeID(int id)
	{
		Employee employee;
		List<Employee>.Enumerator enumerator = base.GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				Employee current = enumerator.Current;
				if (current.EmployeeID != id)
				{
					continue;
				}
				employee = current;
				return employee;
			}
			return null;
		}
		finally
		{
			((IDisposable)enumerator).Dispose();
		}
		return employee;
	}

	private void LoadAllEmployees()
	{
		if (base.Count > 0)
		{
			base.Clear();
		}
		SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString);
		SqlCommand sqlCommand = new SqlCommand("SELECT [EmployeeID], [LastName], [FirstName], [Title], [TitleOfCourtesy], [BirthDate], [Notes] FROM [Employees]", sqlConnection)
		{
			CommandType = CommandType.Text
		};
		try
		{
			sqlConnection.Open();
			SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
			while (sqlDataReader.Read())
			{
				base.Add(new Employee(sqlDataReader));
			}
		}
		finally
		{
			sqlConnection.Close();
		}
	}
}