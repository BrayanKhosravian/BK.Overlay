using BK.Overlay.Core.Shapes;
using System.Windows;
using System.Windows.Controls;

namespace BK.Overlay.Controls.Common.Common
{
	public class CanvasItemSelector : DataTemplateSelector
	{
		public DataTemplate LineTemplate { get; set; }
		public DataTemplate CircleTemplate { get; set; }

		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			var shape = item as Shape;

			switch (shape)
			{
				case Circle _: return CircleTemplate;
				case Line _: return LineTemplate;

				default: return base.SelectTemplate(item, container);
			}
		}
	}
}
