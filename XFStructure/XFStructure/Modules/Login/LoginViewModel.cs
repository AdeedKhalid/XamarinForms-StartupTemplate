using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamvvm;
using XFStructure.Modules.Signup;
using DataStore.Customization.Stores;
using DataStore.Customization.Responses;

namespace XFStructure.Modules.Login
{
    public class LoginViewModel : BasePageModel
    {
        #region Properties
        private string _username;
        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged("Username"); }
        }
        private List<TestResponse> _testResponse;
        public List<TestResponse> TestResponse
        {
            get { return _testResponse; }
            set { SetField(ref _testResponse, value); }
        }
        #endregion


        #region Commands
        private ICommand _navigateToSignup;
        public ICommand NavigateToSignup => _navigateToSignup ?? (_navigateToSignup = new Command(ExecuteNavigateToSignupCommand));
        #endregion


        #region Methods
        private async void ExecuteNavigateToSignupCommand(object obj)
        {
            var param = obj as string;
            switch (param)
            {
                case "NavigateToSignup":
                    //await this.PushPageFromCacheAsync<SignupViewModel>();
                    await this.PushPageFromCacheAsync<SignupViewModel>(c => c.Name = "Adeed Khalid");
                    break;
            }
        }

        public LoginViewModel()
        {
            TestResponse = new List<TestResponse>();
        }

        public override async void OnAppearing()
        {
            base.OnAppearing();

            TestResponse = await new TestStore().GetTestAsync();
        }
        #endregion

    }
}
