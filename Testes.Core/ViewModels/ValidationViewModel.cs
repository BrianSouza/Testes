using Cirrious.MvvmCross.ViewModels;
using System.Windows.Input;
using System.Collections.ObjectModel;
using MvvmValidation;
using System;
using Cirrious.CrossCore;
using Testes.Core.Services;


namespace Testes.Core.ViewModels
{
    public class ValidationViewModel 
		: BaseViewModel
    {
		
		private ObservableCollection<ClasseTeste> _Linhas;
		public ObservableCollection<ClasseTeste> Linhas
		{
			get{ 
				return _Linhas; 
			}
			set{
				_Linhas = value;
				RaisePropertyChanged (() => Linhas);
			}
		}

		public ValidationViewModel ()
		{
			Linhas = new ObservableCollection<ClasseTeste> ();

			Validator.AddRule (() => Codigo, () => RuleResult.Assert (ValidaNumeros(Codigo) , "Código deve ser um número maior do que 0."));
			Validator.AddRule (() => Valor, () => RuleResult.Assert (ValidaNumeros(Valor), "Valor deve ser um número maior do que 0."));
		}

		public bool ValidaNumeros<T>(T numero)
		{
			if (numero.GetType () == typeof(int)) {

				if (Convert.ToInt32(numero) > 0)
					return true;
				else
					return false;
			} else if (numero.GetType () == typeof(double)) {
				if (Convert.ToDouble(numero) > 0)
					return true;
				else
					return false;
			} else
				return false;
		}

		private ObservableDictionary<string,string> _Errors;
		public ObservableDictionary<string,string> Errors
		{
			get
			{
				return _Errors;
			}
			set {
				_Errors = value;
				RaisePropertyChanged (() => Errors);
			}
		}

		private double _Valor;
		public double Valor
		{
			get
			{
				return _Valor;
			}
			set {
				_Valor = value;
				RaisePropertyChanged (() => Valor);
			}
		}

		private int _Codigo;
		public int Codigo
		{
			get{
				
				return _Codigo;
			}
			set{
				_Codigo = value;
				RaisePropertyChanged ();
			}
		}

		public ICommand AddCommand
		{
			get { 
			    return new MvxCommand (AddLinha);
				
			}
		}
		private void AddLinha()
		{
			if(!Validate("ALL"))
				return;
			
			Linhas.Add (
				new ClasseTeste () {
					Id = Codigo,
					Valor = Valor
				});
		}
		private bool Validate(string nomePropriedade)
		{
			ValidationResult result = null;
			switch (nomePropriedade) 
			{
			case "Codigo":
					result = Validator.GetResult (() => Codigo);
					break;
			case "Valor":
					result = Validator.GetResult (() => Valor);
					break;
			case "ALL":
					result = Validator.ValidateAll();
			break;

			}

			Errors = result.AsObservableDictionary();
			return result.IsValid;
		}


		public ICommand SelectedItem
		{
			get {
				return new MvxCommand<ClasseTeste> (RemoveSelectedItem);

			}
		}


		public void RemoveSelectedItem(ClasseTeste item)
		{
			if (item != null) {
				Mvx.Resolve<IAlertMessage> ().Confirm ("Deseja remover está linha ?", async () =>  {
					Linhas.Remove (item);
				}, "Remover Linha", "Sim", "Não");

				
			}
		}
    }
}
