using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamvvm;

namespace XFStructure.Modules.Login
{
    public partial class Login : ContentPage, IBasePage<LoginViewModel>
    {
        public Login()
        {
            InitializeComponent();
        }
    }
}