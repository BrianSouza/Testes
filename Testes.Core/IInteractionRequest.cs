using System;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.CrossCore.Core;

namespace Testes.Core
{
	public class Confirmation
	{
		public string Message { get; private set; }
		public bool Confirmed { get; set; }
		public Confirmation(string message)
		{
			Message = message;
		}
	}

	public interface IInteractionRequest
	{
		event EventHandler<InteractionRequestedEventArgs> Raised;
	}

	public class InteractionRequestedEventArgs : EventArgs
	{
		public Action Callback { get; private set; }
		public object Context { get; private set; }
		public InteractionRequestedEventArgs(object context, Action callback)
		{
			Context = context;
			Callback = callback;
		}
	}

	public class InteractionRequest<T> : IInteractionRequest
	{
		public event EventHandler<InteractionRequestedEventArgs> Raised;

		public void Raise(T context, Action<T> callback)
		{
			var handler = this.Raised;
			if (handler != null)
			{
				handler(
					this, 
					new InteractionRequestedEventArgs(
						context, 
						() => callback(context)));
			}
		}

	}



}

