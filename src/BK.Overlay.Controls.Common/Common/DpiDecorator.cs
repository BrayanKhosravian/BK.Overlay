using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BK.Overlay.Controls.Common.Common
{
	[DebuggerStepThrough]
	public class DpiDecorator : Decorator
	{
		public DpiDecorator()
		{
			this.Loaded += (s, e) =>
			{
				return;
				Matrix m = PresentationSource.FromVisual(this).CompositionTarget.TransformToDevice;
				ScaleTransform dpiTransform = new ScaleTransform(1 / m.M11, 1 / m.M22);
				if (dpiTransform.CanFreeze)
					dpiTransform.Freeze();
				this.LayoutTransform = dpiTransform;
			};
		}
	}
}
