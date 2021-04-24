using System;
using System.Globalization;
using System.Windows.Data;

namespace BK.Overlay.UserControls.Converters
{
	class SystemColorToMediaColorConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(value is System.Drawing.Color color))
				throw new InvalidOperationException($"Wrong type!");

			return ColorConverterHelpers.SystemColorToMediaColor(color);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(value is System.Windows.Media.Color color))
				throw new InvalidOperationException($"Wrong type!");

			return ColorConverterHelpers.MediaColorToSystemColor(color);
		}

	}
}
