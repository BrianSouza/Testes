using System;
using Testes.Core;
using System.Threading.Tasks;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Droid.Platform;
using Android.App;

namespace Testes.MvvmValidation.Services
{
	public class DialogService : IDialogService
	{
		#region IDialogService implementation

		public async Task<bool?> ShowAsync (string message, string title, string OKButtonContent, string CancelButtonContent)
		{
			var tcs = new TaskCompletionSource<bool?>();

			var mvxTopActivity = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
			AlertDialog.Builder builder = new AlertDialog.Builder(mvxTopActivity.Activity);
			builder.SetTitle(title)
				.SetMessage(message)
				.SetCancelable(false)
				.SetPositiveButton(OKButtonContent, (s, args) =>
					{
						tcs.SetResult(true);
					})
				.SetNegativeButton(CancelButtonContent, (s, args) =>
					{
						tcs.SetResult(false);
					});

			builder.Create().Show();
			return await tcs.Task;
		}

		#endregion

		public DialogService ()
		{
		}
	}
}

