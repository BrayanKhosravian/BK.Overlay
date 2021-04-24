using System;
using System.Drawing;

namespace BK.Overlay.Core.Shapes
{
	public class Circle : Shape
	{
		private double _x1;
		private double _y1;

		public Circle() { }

		public Circle(double x1, double y1, Color color, double thickness, Guid guid, double diameter)
			: base(x1, y1, color, thickness, guid)
		{
			Diameter = diameter;
		}

		public double Diameter { get; set; }

		public override double X1
		{
			get => _x1 - Diameter / 2;
			set => _x1 = value;
		}

		public override double Y1
		{
			get => _y1 - Diameter / 2;
			set => _y1 = value;
		}
	}
}
