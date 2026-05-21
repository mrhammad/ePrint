using System;
using System.Data.SqlClient;
using System.Reflection;

class TestCustomizeCompile
{
	static void Main(string[] args)
	{
		var asm = Assembly.LoadFrom(@"d:\Globo Technologies\ePrint\MyFirstProject\ePrint\bin\ePrint.dll");
		var seeds = asm.GetType("nmsCommon.NewCompanyDefaultSeeds");
		var method = seeds.GetMethod("ApplyCustomizeViews", BindingFlags.Public | BindingFlags.Static);
		int companyId = int.Parse(args != null && args.Length > 0 ? args[0] : "2180");
		var conn = new SqlConnection("Data Source=localhost;Initial Catalog=eprint_demo;User ID=sa;Password=P@ssword883104;");
		conn.Open();
		method.Invoke(null, new object[] { companyId, conn });
		conn.Close();
		Console.WriteLine("ApplyCustomizeViews OK for " + companyId);
	}
}
