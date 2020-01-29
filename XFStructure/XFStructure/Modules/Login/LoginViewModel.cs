﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamvvm;
using XFStructure.Modules.Signup;

namespace XFStructure.Modules.Login
{
    public class LoginViewModel : BasePageModel
    {
        #region Properties

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
                    await this.PushPageFromCacheAsync<SignupViewModel>();
                    break;
            }
        }

        public LoginViewModel()
        {

        }
        #endregion

    }
}