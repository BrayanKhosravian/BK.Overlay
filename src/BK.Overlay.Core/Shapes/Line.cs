using System;
using System.Drawing;

namespace BK.Overlay.Core.Shapes
{
	public class Line : Shape
	{
		public Line() { }

		public Line(double x1, double y1, Color color, double thickness, Guid guid, double x2, double y2)
			: base(x1, y1, color, thickness, guid)
		{
			X2 = x2;
			Y2 = y2;
		}

		public double X2 { get; set; }
		public double Y2 { get; set; }
	}
}
