using Cirrious.MvvmCross.ViewModels;
using System.Windows.Input;
using System.Collections.ObjectModel;
using MvvmValidation;


namespace Testes.Core.ViewModels
{
    public class ValidationViewModel 
		: MvxViewModel
    {
		private ValidationHelper validator;
		private ObservableCollection<ClasseTeste> _Linhas;
		public ValidationViewModel ()
		{
			Linhas = new ObservableCollection<ClasseTeste> ();
			validator = new ValidationHelper ();
			validator.AddRule (() => Codigo, () => RuleResult.Assert (Valor > 0, "Email is required."));
			validator.AddRule (() => Valor, () => RuleResult.Assert (Valor > 0, "Password is required."));
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
				Validate ();
				_Codigo = value;
				RaisePropertyChanged ();
			}
		}
		public ObservableCollection<ClasseTeste> Linhas
		{
			get{ return _Linhas; }
			set{
				_Linhas = value;
				RaisePropertyChanged (() => Linhas);

			}
		}
		public ICommand AddCommand
		{
			get { 
				Validate ();
				return new MvxCommand(() => Linhas.Add(
					new ClasseTeste(){
						Id = Codigo,
						Valor = Valor
					}));
			}
		}

		private void Validate()
		{
			

			var result = validator.ValidateAll();

			var Errors = result.AsObservableDictionary();
		}
    }
}
