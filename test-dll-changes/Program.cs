using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using core_lib;

namespace test_dll_changes
{
	class Program
	{
		static int Main(string[] args)
		{
			try
			{
				var clazz = SomeApi.ReturnMe();
				Console.WriteLine(clazz.DoSomeStuff("Hello from test-dll-changes (4.0)"));
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				return -1;
			}
			return 0;
		}
	}
}
