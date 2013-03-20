using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using core_lib;

namespace test_dll_changes
{
	class Program
	{
		static void Main(string[] args)
		{
			var clazz = SomeApi.ReturnMe();
			Console.WriteLine(clazz.DoSomeStuff("Hello from test-dll-changes (4.0)"));
		}
	}
}
