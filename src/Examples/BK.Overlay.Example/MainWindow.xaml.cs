using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using BK.Overlay.Core.Shapes;
using BK.Overlay.Example.ViewModels;
using BK.Overlay.UserControls;

namespace BK.Overlay.Example
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private OverlayWindow _overlay = new OverlayWindow();
		private OverlayViewModel _vm = new OverlayViewModel();

		public MainWindow()
		{
			InitializeComponent();

		
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			_overlay.DataContext = _vm;
			_overlay.Show();
		}

		private void OnAddShape(object sender, RoutedEventArgs e)
		{
			var x = int.Parse(xValue.Text);
			var y = int.Parse(yValue.Text);
			var line = new Line(x, y, System.Drawing.Color.Red, 50, Guid.NewGuid(), x + 50, y + 50);
			_vm.CanvasItems.Add(line);
		}
	}
}
