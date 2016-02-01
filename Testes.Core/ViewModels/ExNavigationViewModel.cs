using System;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using Testes.Core.DATA;

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

		public void Init()
		{
//			Key = parameters.Key;
			string ler = WRSFiles.Ler();
			var teste = JsonConvert.DeserializeObject<ObservableCollection<ClasseTeste>> (Key);
		}

		public class Parameters
		{
			public string Key { get; set; }
		}
	}
}

