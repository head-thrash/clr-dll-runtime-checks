using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using NUnit.Framework;

namespace test_suite
{
	class Program
	{
		static void Main(string[] args)
		{			
			AssertDoTest("test-dll-changes", "vanilla");
			AssertDoTest("test-dll-changes-3-5", "vanilla");
			
			AssertDoTest("test-dll-changes", "changed");
			AssertDoTest("test-dll-changes-3-5", "changed");

			AssertDoTest("test-dll-changes", "vanilla-signed");
			AssertDoTest("test-dll-changes-3-5", "vanilla-signed");

			AssertDoTest("test-dll-changes", "changed-signed");
			AssertDoTest("test-dll-changes-3-5", "changed-signed");

			Console.WriteLine("Press any key.");
			Console.ReadLine();
		}

		static void AssertDoTest(string targetFolder, string artifact)
		{
			try
			{
				DoTest(targetFolder, artifact);
			}
			catch (AssertionException ex)
			{
				Console.WriteLine("FAIL {0} - {1}, {2}",
					targetFolder, artifact, ex.InnerException);
				return;
			}
			Console.WriteLine("PASS {0} - {1}", targetFolder, artifact);
		}

		static void DoTest(string targetFolder, string artifact)
		{
			Assert.That(Directory.Exists(targetFolder));
			var libPath = Path.Combine("artifacts", artifact);
			Assert.That(Directory.Exists(libPath));
			Cleanup(targetFolder);
			try
			{
				File.Copy(Path.Combine(libPath, "core-lib.dll"), 
					Path.Combine(targetFolder, "bin", "Release", "core-lib.dll"));

				var spi = new ProcessStartInfo
				{
					CreateNoWindow = true,
					WindowStyle = ProcessWindowStyle.Hidden,
					RedirectStandardError = true,
					UseShellExecute = false,
					FileName = Path.Combine(targetFolder, "bin", "Release", Path.GetFileName(targetFolder) + ".exe")
				};
				var p = Process.Start(spi);
				var result = p.WaitForExit(1000);
				var trials = 3;
				while (trials-- > 0 && !result)
					result = p.WaitForExit(1000);
				if (p.ExitCode != 0)
				{
					throw new AssertionException("Process Failed with exit code="+p.ExitCode);
				}
			}
			finally
			{
				Cleanup(targetFolder);
			}
		}

		static void Cleanup(string targetFolder)
		{
			try{File.Delete(Path.Combine(targetFolder, "bin", "Release", "core-lib.dll"));}catch {}
		}
	}
}
