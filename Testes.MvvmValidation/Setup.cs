using Android.Content;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.CrossCore;
using Testes.Core;
using Testes.Core.Services;
using Cirrious.MvvmCross.Plugins.File;

namespace Testes.MvvmValidation
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
			Mvx.RegisterType<IAlertMessage, AlertMessage>();
			Mvx.RegisterType<IMvxFileStore, WRService>();
            return new Core.App();
        }
		
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

		protected override void InitializeLastChance()
		{
			base.InitializeLastChance();
		}
    }
}