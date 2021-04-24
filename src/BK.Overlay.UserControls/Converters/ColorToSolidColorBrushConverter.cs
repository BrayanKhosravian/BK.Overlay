using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace BK.Overlay.UserControls.Converters
{
	public class ColorToSolidColorBrushConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (null == value)
			{
				return null;
			}

			if (value is System.Drawing.Color c)
			{
				var color = ColorConverterHelpers.SystemColorToMediaColor(c);
				return new SolidColorBrush(color);
			}

			Type type = value.GetType();
			throw new InvalidOperationException("Unsupported type [" + type.Name + "]");
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
