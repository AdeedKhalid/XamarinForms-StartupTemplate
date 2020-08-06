using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamvvm;
using XFStructure.BasePages;

namespace XFStructure.Modules.Signup
{
    public partial class Signup : BasePage, IBasePage<SignupViewModel>
    {
        public Signup()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}