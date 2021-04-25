using BK.Overlay.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace BK.Overlay.Example.ViewModels
{
	abstract class ViewModelBase : INotifyPropertyChanging, INotifyPropertyChanged
	{
		public event PropertyChangingEventHandler PropertyChanging;
		public event PropertyChangedEventHandler PropertyChanged;

		protected void SetProperty<T>(ref T backingField, in T value, [CallerMemberName] string propertyName = "")
		{
			if (EqualityComparer<T>.Default.Equals(backingField, value)) return;
			OnPropertyChaning(propertyName);
			backingField = value;
			OnPropertyChanged(propertyName);
		}

		public void OnPropertyChaning([CallerMemberName] string propertyName = "") =>
			PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));

		public void OnPropertyChanged([CallerMemberName] string propertyName = "") =>
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}
