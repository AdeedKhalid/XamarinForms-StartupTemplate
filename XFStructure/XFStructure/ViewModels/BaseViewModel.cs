﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamvvm;

namespace XFStructure.ViewModels
{
    public class BaseViewModel : BasePageModel
    {
        #region Properties
        private bool isLoading;
        public virtual bool IsLoading
        {
            get { return isLoading; }
            set { SetField(ref isLoading, value); }
        }
        #endregion
    }
}
