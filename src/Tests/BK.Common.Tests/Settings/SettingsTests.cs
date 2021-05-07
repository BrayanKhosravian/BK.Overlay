using BK.Common.Settings;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BK.Common.Tests.Settings
{
	
	public class SettingsTests
	{
		[OneTimeSetUp]
		public void OneTimeSetup()
		{
			var currentDir = Path.GetDirectoryName(typeof(SettingsTests).Assembly.Location);
			var dir = Path.Combine(currentDir, "TestData");

			if (!Directory.Exists(dir))
				Directory.CreateDirectory(dir);

			Environment.CurrentDirectory = dir;
		}

		[SetUp]
		public void Setup()
		{
		}

		
	}
}
