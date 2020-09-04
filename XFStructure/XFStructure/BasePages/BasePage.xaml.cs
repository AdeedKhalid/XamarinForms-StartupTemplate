using DataStore.Customization.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFStructure.ViewModels;

namespace XFStructure.BasePages
{
    public partial class BasePage : ContentPage
    {
        public BasePage()
        {
            InitializeComponent();
            NavigationPage.SetBackButtonTitle(this, "");
        }

        protected override void OnDisappearing()
        {
            if (BindingContext != null && BindingContext is BasePageViewModel)
                (BindingContext as BasePageViewModel).CancelAllTasks();
            base.OnDisappearing();
        }

        public View MainContent
        {
            get { return contentView.Content; }
            set
            {
                contentView.Content = value;
            }
        }
    }
}