﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamvvm;

namespace XFStructure.Modules.Signup
{
    public class SignupViewModel : BasePageModel
    {
        #region Properties

        #endregion


        #region Commands
        private ICommand _navigateToSignin;
        public ICommand NavigateToSignin => _navigateToSignin ?? (_navigateToSignin = new Command(ExecuteNavigateToSigninCommand));
        #endregion


        #region Methods
        private async void ExecuteNavigateToSigninCommand(object obj)
        {
            var param = obj as string;
            switch (param)
            {
                case "NavigateToSignin":
                    await this.PopPageAsync();
                    break;
            }
        }
        public SignupViewModel()
        {

        }
        #endregion
    }
}