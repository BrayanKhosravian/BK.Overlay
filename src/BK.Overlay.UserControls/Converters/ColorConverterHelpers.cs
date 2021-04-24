using System.Collections.Generic;
using System.Text;

namespace BK.Overlay.UserControls.Converters
{
	public static class ColorConverterHelpers
	{
		public static System.Windows.Media.Color SystemColorToMediaColor(System.Drawing.Color systemColor)
		{
			var mediaColor = new System.Windows.Media.Color();
			mediaColor.A = systemColor.A;
			mediaColor.R = systemColor.R;
			mediaColor.G = systemColor.G;
			mediaColor.B = systemColor.B;
			return mediaColor;
		}

		public static System.Drawing.Color MediaColorToSystemColor(System.Windows.Media.Color mediaColor)
		{
			return System.Drawing.Color.FromArgb(mediaColor.A, mediaColor.R, mediaColor.G, mediaColor.B);

		}
	}
}
