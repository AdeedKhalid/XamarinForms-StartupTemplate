using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DataStore.Customization.Helpers
{
    public static class TaskCancellation
    {
        private static CancellationTokenSource _cancellationTokenSource;

        public static void CancelAllTasks() => _cancellationTokenSource?.Cancel();

        public static CancellationToken GetCurrentCancellationToken()
        {
            if (_cancellationTokenSource == null || _cancellationTokenSource.IsCancellationRequested)
            {
                _cancellationTokenSource = new CancellationTokenSource();
                _cancellationTokenSource.CancelAfter(10000);
            }
            return _cancellationTokenSource.Token;
        }
    }
}
