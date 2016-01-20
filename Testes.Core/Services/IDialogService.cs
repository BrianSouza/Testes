using System;
using System.Threading.Tasks;

namespace Testes.Core
{
	public interface IDialogService
	{
		Task<bool?> ShowAsync(string message, string title, string OKButtonContent, string CancelButtonContent);
	}
}

