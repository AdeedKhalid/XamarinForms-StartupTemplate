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
        private CancellationTokenSource currentServiceCallCancellationTokenSource;

        internal void CancelAllTasks() => currentServiceCallCancellationTokenSource?.Cancel();

        private CancellationToken GetCurrentCancellationToken()
        {
            if (currentServiceCallCancellationTokenSource == null || currentServiceCallCancellationTokenSource.IsCancellationRequested)
            {
                currentServiceCallCancellationTokenSource = new CancellationTokenSource();
            }

            return currentServiceCallCancellationTokenSource.Token;
        }

        protected async Task<TResult> PerformServiceCall<TResult>(Func<Task<TResult>> serviceCallAction)
        {
            var cancellationToken = GetCurrentCancellationToken();
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
                        cancellationToken.ThrowIfCancellationRequested();
                        result = await serviceCallAction?.Invoke();
                        cancellationToken.ThrowIfCancellationRequested();
                    }
                    catch (Exception ex)
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
