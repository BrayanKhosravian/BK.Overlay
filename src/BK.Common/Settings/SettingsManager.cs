using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BK.Common.Settings
{
	public class SettingsManager : SettingsManagerBase
	{
		protected override string SettingsFilePath
		{
			get
			{
				var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
				var fileName = "Settings.json";
				var path = Path.Combine(basePath, fileName);
				return path;
			}
		}
	}

	public abstract class SettingsManagerBase
	{
		// template property pattern
		protected abstract string SettingsFilePath { get; }

		public SettingsManagerBase()
		{
			if (!SettingsFilePath.EndsWith(".json"))
				throw new ArgumentException($"{nameof(SettingsFilePath)} has to be a '.json' file");

			CreateSettingsFile(SettingsFilePath);
		}

		public void SaveSetting<T>(string key, T value)
		{
			var settings = ReadJson(SettingsFilePath);

			if (!settings.TryGetValue(key, out var setting))
				throw new SettingsKeyNotFoundException();

			setting[key] = value.ToString();

			var serializer = new JsonSerializer();
			using var sw = new StreamWriter(SettingsFilePath);
			using var writer = new JsonTextWriter(sw);
			serializer.Serialize(writer, settings);
		}

		public T LoadSetting<T>(string key)
		{
			var settings = ReadJson(SettingsFilePath);
			
			if (!settings.TryGetValue(key, out var setting))
				throw new SettingsKeyNotFoundException();
			
			var result = ChangeType<T>((string)setting);
			return result;

		}

		public bool TryClearSettingsFile()
		{
			if (!File.Exists(SettingsFilePath))
				return false;

			File.Delete(SettingsFilePath);
			File.Create(SettingsFilePath);
			return true;
		}
		
		private static void CreateSettingsFile(string settingsFilePath)
		{
			if (File.Exists(settingsFilePath))
				return;

			var dir = Path.GetDirectoryName(settingsFilePath);

			if (!Directory.Exists(dir))
				Directory.CreateDirectory(dir);

			using var sw = File.CreateText(settingsFilePath);
			sw.WriteLine($"{{ {Environment.NewLine} }}");
		}

		private static JObject ReadJson(string path)
		{
			var settingsText = File.ReadAllText(path);
			var settings = JObject.Parse(settingsText);
			return settings;
		}

		private static T ChangeType<T>(string value)
		{
			var result = (T)Convert.ChangeType(value, typeof(T));
			return result;
		}

	}

	
}
