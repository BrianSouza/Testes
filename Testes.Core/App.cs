using Cirrious.CrossCore.IoC;
using Cirrious.CrossCore;
using Chance.MvvmCross.Plugins.UserInteraction;

namespace Testes.Core
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
				
			RegisterAppStart<ViewModels.ValidationViewModel>();

        }
    }
}