using System;
using System.Collections.Generic;
using System.Text;

namespace BK.Overlay.UserControls
{
	public class OverlayWindowBuilder
	{
		private OverlayWindow _overlay;

		public OverlayWindowBuilder Init()
		{
			_overlay = new OverlayWindow();
			return this;
		}


	}
}
