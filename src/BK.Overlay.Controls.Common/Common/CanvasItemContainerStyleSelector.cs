using BK.Overlay.Core.Shapes;
using System;
using System.Windows;
using System.Windows.Controls;

namespace BK.Overlay.Controls.Common.Common
{
	public class CanvasItemContainerStyleSelector : StyleSelector
	{
		public Style CircleStyle { get; set; }

		public override Style SelectStyle(object item, DependencyObject container)
		{
			if (CircleStyle == null)
				throw new ArgumentNullException($"{nameof(CanvasItemContainerStyleSelector)}: {nameof(CircleStyle)} is not set!");

			if (item is Circle)
				return CircleStyle;

			return base.SelectStyle(item, container);
		}
	}
}
