using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamvvm;
using XFStructure.BasePages;

namespace XFStructure.Modules.Login
{
    public partial class Login : BasePage, IBasePage<LoginViewModel>
    {
        public Login()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is LoginViewModel vm)
            {
                vm.Username = "Adeed Khalid";
            }
        }
    }
}