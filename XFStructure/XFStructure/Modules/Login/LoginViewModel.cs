using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamvvm;
using XFStructure.Modules.Signup;
using DataStore.Customization.Stores;
using DataStore.Customization.Responses;
using DataStore.Customization.Requests;
using XFStructure.ViewModels;

namespace XFStructure.Modules.Login
{
    public class LoginViewModel : BasePageViewModel
    {
        #region Properties
        private string _username;
        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged("Username"); }
        }
        private List<TestResponseGET> _testResponseGET;
        public List<TestResponseGET> TestResponseGET
        {
            get { return _testResponseGET; }
            set { SetField(ref _testResponseGET, value); }
        }
        private TestResponsePOST _testResponsePOST;
        public TestResponsePOST TestResponsePOST
        {
            get { return _testResponsePOST; }
            set { SetField(ref _testResponsePOST, value); }
        }
        private TestResponsePUT _testResponsePUT;
        public TestResponsePUT TestResponsePUT
        {
            get { return _testResponsePUT; }
            set { SetField(ref _testResponsePUT, value); }
        }
        private TestResponseDELETE _testResponseDELETE;
        public TestResponseDELETE TestResponseDELETE
        {
            get { return _testResponseDELETE; }
            set { SetField(ref _testResponseDELETE, value); }
        }
        #endregion


        #region Commands
        private ICommand _navigateToSignup;
        public ICommand NavigateToSignup => _navigateToSignup ?? (_navigateToSignup = new Command(ExecuteNavigateToSignupCommand));

        private ICommand _invokeAPICalls;
        public ICommand InvokeAPICalls => _invokeAPICalls ?? (_invokeAPICalls = new Command(ExecuteInvokeAPICallsCommand));
        #endregion


        #region Methods
        public LoginViewModel()
        {
            TestResponseGET = new List<TestResponseGET>();
            TestResponsePOST = new TestResponsePOST();
            TestResponsePUT = new TestResponsePUT();
            TestResponseDELETE = new TestResponseDELETE();
        }

        public override void OnAppearing()
        {
            base.OnAppearing();
        }

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

        private async void ExecuteInvokeAPICallsCommand(object obj)
        {
            TestResponseGET = await PerformServiceCall(async () => await new TestStoreGET().GetTestAsync());

            TestResponsePOST = await PerformServiceCall(async () => await new TestStorePOST().PostTestAsync(
                new TestRequestPOST() { name = "test", age = "50", salary = "50000" }
            ));

            TestResponsePUT = await PerformServiceCall(async () => await new TestStorePUT().PutTestAsync(
                50,
                new TestRequestPUT() { name = "test", age = "50", salary = "50000" }
            ));

            TestResponseDELETE = await PerformServiceCall(async () => await new TestStoreDELETE().DeleteTestAsync(50));
        }
        #endregion

    }
}
