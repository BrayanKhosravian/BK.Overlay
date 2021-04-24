using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace BK.Overlay.Example.Commands
{
	class Command<T> : ICommand
	{
		private readonly Action<T> _execute;
		private readonly Predicate<T> _canExecute;

		public Command(Action<T> execute)
		{
			_execute = execute;
			_canExecute = _ => true;
		}

		public Command(Action<T> execute, Predicate<T> canExecute)
		{
			_execute = execute;
			_canExecute = canExecute;
		}

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return _canExecute.Invoke((T)parameter);
		}

		public void Execute(object parameter)
		{
			if (!CanExecute(parameter)) return;
			_execute.Invoke((T)parameter);
		}
	}

	
}
