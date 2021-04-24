using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BK.Overlay.UserControls
{
	// https://stackoverflow.com/questions/7174315/understanding-wpf-deriving-window-class
	// https://blog.magnusmontin.net/2013/03/16/how-to-create-a-custom-window-in-wpf/
	public class CustomWindow : Window
	{
		public CustomWindow()
		{
            
            //StyleProperty.OverrideMetadata(typeof(Window), new FrameworkPropertyMetadata(TryFindResource(typeof(Window))));

        }
       
    }
}
