using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;

namespace Testes.MvvmValidation.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class ValidationView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
			SetContentView(Resource.Layout.ValidationView);
        }
    }
}