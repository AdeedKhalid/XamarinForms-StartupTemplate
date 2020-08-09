using DataStore.Customization.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamvvm;

namespace XFStructure.ViewModels
{
    public class BasePageViewModel : BasePageModel, IBasePageModel
    {
        #region Properties
        private bool isLoading;
        public virtual bool IsLoading
        {
            get { return isLoading; }
            set { SetField(ref isLoading, value); }
        }
        #endregion

        #region PerformServiceCall
        protected async Task<TResult> PerformServiceCall<TResult>(Func<Task<TResult>> serviceCallAction)
        {
            TResult result = default;
            var current = Connectivity.NetworkAccess;
            if (current != NetworkAccess.Internet)
            {
                await Application.Current.MainPage.DisplayAlert("", "Looks like you're not connected to the internet.", "OK");
            }
            else
            {
                if (!IsLoading)
                {
                    try
                    {
                        IsLoading = true;
                        result = await serviceCallAction?.Invoke();
                    }
                    catch (OperationCanceledException)
                    {
                        await Application.Current.MainPage.DisplayAlert("", "Server is not responding!", "OK");
                    }
                    catch (Exception)
                    {
                        await Application.Current.MainPage.DisplayAlert("Unable to process", "Your request could not be processed at this time.", "OK");
                    }
                    finally
                    {
                        IsLoading = false;
                    }
                }
            }
            return result;
        }
        #endregion
    }
}
