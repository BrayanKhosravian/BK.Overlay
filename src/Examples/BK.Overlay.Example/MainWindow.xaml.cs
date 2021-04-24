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
using System.Windows.Shapes;
using BK.Overlay.Example.Overlays;
using BK.Overlay.Example.ViewModels;
using BK.Overlay.UserControls;

namespace BK.Overlay.Example
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			var overlayFactories = CreateOverlayFactories();
			var buttons = CreateButtons(overlayFactories);

			foreach (var button in buttons)
			{
				MainWindowStackPanel.Children.Add(button);
			}
		}

		private IEnumerable<Func<UserControls.Overlay>> CreateOverlayFactories()
		{
			yield return () => new StaticOverlay();
			yield return () => 
			{
				var observableOverlay = new ObservableOverlay();
				var vm = new ObservableOverlayViewModel();
				observableOverlay.DataContext = 
			};
		}

		private IEnumerable<Button> CreateButtons(IEnumerable<Func<UserControls.Overlay>> overlayFactories)
		{
			foreach (var overlayFactory in overlayFactories)
			{
				yield return CreateButton(overlayFactory);
			}
		}

		private Button CreateButton(Func<UserControls.Overlay> overlayFactory)
		{
			var b = new Button();
			var overlay = overlayFactory.Invoke();

			b.Content = overlay.GetType().ToString();
			b.Click += (sender, e) => overlayFactory.Invoke().Show();
			return b;
		}
	}
}
