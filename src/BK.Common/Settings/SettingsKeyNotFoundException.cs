using System;
using System.Runtime.Serialization;

namespace BK.Common.Settings
{
	class SettingsKeyNotFoundException : ArgumentException
	{
		public SettingsKeyNotFoundException()
		{
		}

		public SettingsKeyNotFoundException(string message) : base(message)
		{
		}

		public SettingsKeyNotFoundException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected SettingsKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}

	
}
