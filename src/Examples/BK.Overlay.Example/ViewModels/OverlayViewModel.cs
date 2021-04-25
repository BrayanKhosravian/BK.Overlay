using BK.Overlay.Core.Shapes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BK.Overlay.Example.ViewModels
{
	class OverlayViewModel : ViewModelBase
	{
		public ObservableCollection<Shape> CanvasItems { get; set; } = new ObservableCollection<Shape>();
	}
}
