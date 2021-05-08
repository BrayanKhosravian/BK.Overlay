using BK.CheatSheatOverlay.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Windows.Media;

namespace BK.CheatSheatOverlay.ViewModels
{
	// todo save this in settings
	public class CheatSheatConfigurationViewModel : ViewModelBase
	{
		private int _xSize;
		private int _ySize;
		private int _opacity;
		private Color _backgroundColor;

		public Command<bool> IsActiveCommand { get; }
		public Command<bool> CanClickThroughCommand { get; }

		public CheatSheatConfigurationViewModel()
		{
			IsActiveCommand = new Command<bool>(isActive =>
			{
				// todo show or hide overlay
			});

			CanClickThroughCommand = new Command<bool>(canClickThrough =>
			{
				// todo make overlay click through or not
			});
		}

		public int XSize 
		{ 
			get => _xSize; 
			set => TrySetProperty(ref _xSize, value); 
		}

		public int YSize 
		{ 
			get => _ySize; 
			set => TrySetProperty(ref _ySize, value); 
		}

		public int Opacity 
		{ 
			get => _opacity; 
			set => TrySetProperty(ref _opacity, value); 
		}

		public Color BackgroundColor 
		{ 
			get => _backgroundColor; 
			set => TrySetProperty(ref _backgroundColor, in value); 
		}
	}
}
