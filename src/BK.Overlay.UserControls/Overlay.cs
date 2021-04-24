using BK.Overlay.UserControls.Common;

namespace BK.Overlay.UserControls
{
	public class Overlay : CustomWindow
	{
		public Overlay()
		{
			var resources = new OverlayResources();
			Resources = resources;

			var dpiDecorator = new DpiDecorator();
			

        }
    }
}
