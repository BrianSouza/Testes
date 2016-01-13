using Cirrious.MvvmCross.ViewModels;
using System.Windows.Input;
using System.Collections.ObjectModel;
using MvvmValidation;


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

			Validator.AddRule (() => Codigo, () => RuleResult.Assert (ValidaNumeros(Codigo) , "Código não pode ser vazio ou igual a 0."));
			Validator.AddRule (() => Valor, () => RuleResult.Assert (ValidaNumeros(Valor), "Valor não pode ser vazio ou igual a 0."));
		}

		public bool ValidaNumeros(string numero)
		{
			double dNumero;
//			int iNumero;
			bool bConvertDouble = double.TryParse(numero,out dNumero);
//					bool iConvert
			if (bConvertDouble) {
				if (dNumero > 0)
					return true;
				else
					return false;
			} 
			else
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

		private string _Valor;
		public string Valor
		{
			get
			{
				return _Valor;
			}
			set {
				Validate ("Valor");
				_Valor = value;
				RaisePropertyChanged (() => Valor);
			}
		}

		private string _Codigo;
		public string Codigo
		{
			get{
				
				return _Codigo;
			}
			set{
				Validate ("Codigo");
				_Codigo = value;
				RaisePropertyChanged ();
			}
		}

		public ICommand AddCommand
		{
			get { 
//				if (!Validate("ALL"))
//					return new MvxCommand (() => _Codigo  = "" );
				
			    return new MvxCommand (() => Linhas.Add (
						new ClasseTeste () {
						Id = int.Parse(Codigo),
						Valor = double.Parse(Valor)
						}));
				
			}
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


    }
}
