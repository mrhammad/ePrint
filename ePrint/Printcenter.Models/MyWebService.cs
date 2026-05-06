using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.SessionState;

[ScriptService]
[WebService(Namespace="http://tempuri.org/")]
[WebServiceBinding(ConformsTo=WsiProfiles.BasicProfile1_1)]
public class MyWebService : WebService
{
	private EmployeesList employeesList;

	public MyWebService()
	{
		this.employeesList = new EmployeesList();
		if (HttpContext.Current.Session["MyData"] == null)
		{
			HttpContext.Current.Session["MyData"] = this.employeesList;
		}
	}

	[WebMethod(EnableSession=true)]
	public EmployeesList DeleteEmployeeByEmployeeID(int employeeID)
	{
		Employee employeeByEmployeeID = this.GetEmployeeByEmployeeID(employeeID);
		EmployeesList item = (EmployeesList)HttpContext.Current.Session["MyData"];
		item.Remove(employeeByEmployeeID);
		HttpContext.Current.Session["MyData"] = item;
		return item;
	}

	[WebMethod(EnableSession=true)]
	public Employee GetEmployeeByEmployeeID(int employeeID)
	{
		EmployeesList item = (EmployeesList)HttpContext.Current.Session["MyData"];
		return item.GetEmployeeByEmployeeID(employeeID);
	}

	[WebMethod(EnableSession=true)]
	public EmployeesList UpdateEmployeeByEmployee(Employee employee)
	{
		Employee employeeByEmployeeID = this.GetEmployeeByEmployeeID(employee.EmployeeID);
		EmployeesList item = (EmployeesList)HttpContext.Current.Session["MyData"];
		if (employeeByEmployeeID == null)
		{
			employeeByEmployeeID = new Employee()
			{
				EmployeeID = employee.EmployeeID
			};
			item.Add(employeeByEmployeeID);
		}
		employeeByEmployeeID.LastName = employee.LastName;
		employeeByEmployeeID.FirstName = employee.FirstName;
		employeeByEmployeeID.Title = employee.Title;
		employeeByEmployeeID.TitleOfCourtesy = employee.TitleOfCourtesy;
		employeeByEmployeeID.BirthDate = employee.BirthDate;
		employeeByEmployeeID.Notes = employee.Notes;
		HttpContext.Current.Session["MyData"] = item;
		return item;
	}
}