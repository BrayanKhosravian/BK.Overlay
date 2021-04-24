using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BK.Overlay.Core.Shapes
{
	public abstract class Shape
	{
		protected Shape() { }

		protected Shape(double x1, double y1, Color color, double thickness, Guid guid)
		{
			X1 = x1;
			Y1 = y1;
			Color = color;
			Thickness = thickness;
			Guid = guid;
		}

		public virtual double X1 { get; set; }
		public virtual double Y1 { get; set; }
		public Color Color { get; set; }
		public double Thickness { get; set; }
		public Guid Guid { get; set; }

	}
}
