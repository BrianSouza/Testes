using System;
using Cirrious.MvvmCross.ViewModels;
using System.ComponentModel;
using MvvmValidation;
using System.Collections;

namespace Testes.Core.ViewModels
{
	public class BaseViewModel : MvxViewModel , INotifyDataErrorInfo 
	{
		protected ValidationHelper Validator { get; private set; }
		private NotifyDataErrorInfoAdapter NotifyDataErrorInfoAdapter { get; set; }

		public BaseViewModel()
		{
			Validator = new ValidationHelper();

			NotifyDataErrorInfoAdapter = new NotifyDataErrorInfoAdapter(Validator);
		}

		public IEnumerable GetErrors(string propertyName)
		{
			return NotifyDataErrorInfoAdapter.GetErrors(propertyName);
		}

		public bool HasErrors
		{
			get { return NotifyDataErrorInfoAdapter.HasErrors; }
		}

		public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged
		{
			add { NotifyDataErrorInfoAdapter.ErrorsChanged += value; }
			remove { NotifyDataErrorInfoAdapter.ErrorsChanged -= value; }
		}


	}
}

