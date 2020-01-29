using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamvvm;
using XFStructure.Modules.Login;

namespace Shared.XFStructure
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            XamvvmCore.SetCurrentFactory(new XamvvmFormsFactory(this));

            var withNavigationPage = new NavigationPage(Current.GetPageFromCache<LoginViewModel>() as Page);
            //var withoutNavigationPage = Current.GetPageFromCache<HomeViewModel>() as Page;

            Current.MainPage = withNavigationPage;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
