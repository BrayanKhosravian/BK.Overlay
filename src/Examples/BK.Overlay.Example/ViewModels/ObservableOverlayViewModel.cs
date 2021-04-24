using BK.Overlay.Core.Shapes;
using BK.Overlay.Example.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace BK.Overlay.Example.ViewModels
{
	class ObservableOverlayViewModel : ViewModelBase
	{
		public ObservableOverlayViewModel()
		{
			AddToCanvasCommand = new Command<Shape>(shape => CanvasItems.Add(shape));
		}

		public ICommand AddToCanvasCommand { get; }
	}
}
