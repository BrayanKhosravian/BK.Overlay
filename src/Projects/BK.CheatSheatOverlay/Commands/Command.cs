using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace BK.CheatSheatOverlay.Commands
{
	public class Command<T> : ICommand
	{
		public event EventHandler CanExecuteChanged;

		private readonly Predicate<T> _canExecute;
		private readonly Action<T> _execute;

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

		public bool CanExecute(object parameter) =>
			_canExecute.Invoke((T)parameter);

		public void Execute(object parameter)
		{
			if (CanExecute(parameter))
				_execute.Invoke((T)parameter);
		}
	}
}
