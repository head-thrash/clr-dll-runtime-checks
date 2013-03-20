using System;
using System.Collections.Generic;
using System.Text;
using core_lib;

namespace test_dll_changes_3_5
{
	class Program
	{
		static void Main(string[] args)
		{
			var clazz = SomeApi.ReturnMe();
			Console.WriteLine(clazz.DoSomeStuff("Hello from test-dll-changes (3.5)"));
		}
	}
}
