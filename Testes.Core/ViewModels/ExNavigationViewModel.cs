using System;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace Testes.Core.ViewModels
{
	public class ExNavigationViewModel : BaseViewModel
	{
		public ExNavigationViewModel ()
		{
		}
		private string _key;

		public string Key
		{
			get { return _key; }
			set
			{
				_key = value;
				RaisePropertyChanged(() => Key);
			}
		}

		public void Init(Parameters parameters)
		{
			Key = parameters.Key;
			var teste = JsonConvert.DeserializeObject<ObservableCollection<ClasseTeste>> (Key);
		}

		public class Parameters
		{
			public string Key { get; set; }
		}
	}
}

