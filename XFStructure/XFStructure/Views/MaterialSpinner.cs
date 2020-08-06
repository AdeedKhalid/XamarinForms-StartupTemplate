using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xamarin.Forms;

namespace XFStructure.Views
{
    public class MaterialSpinner : ContentView
    {
        #region Initializations
        Image image;
        private CancellationTokenSource cancellationToken;
        #endregion

        #region Properties
        public static readonly BindableProperty IsRunningProperty = 
            BindableProperty.Create(nameof(IsRunning), typeof(bool),
            typeof(MaterialSpinner), false,
            propertyChanged: (bindable, oldValue, newValue) =>
            {
                if (oldValue != newValue)
                {
                    (bindable as MaterialSpinner).ToggleVisibility((bool)newValue);
                }
            });

        public bool IsRunning
        {
            get { return (bool)GetValue(IsRunningProperty); }
            set { SetValue(IsRunningProperty, value); }
        }
        #endregion

        #region Methods
        public MaterialSpinner()
        {
            try
            {
                IsVisible = IsRunning = false;
                VerticalOptions = LayoutOptions.Start;
                HorizontalOptions = LayoutOptions.Center;
                image = new Image()
                {
                    Source = ImageSource.FromFile("ic_activity_indicator.png"),
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    HeightRequest = 22
                };
                var frame = new CircularFrame
                {
                    BackgroundColor = Color.White,
                    HeightRequest = 40,
                    WidthRequest = 40,
                    CornerRadius = 20,
                    Content = image,
                    Elevation = 8,
                };

                if (Device.RuntimePlatform == Device.iOS)
                {
                    frame.CornerRadius = 40;
                }

                Content = frame;
            }
            catch (Exception ex)
            {
                //App.Logger.Report(ex);
            }
        }

        private async void ToggleVisibility(bool isRunning)
        {
            try
            {

                if (isRunning)
                {
                    IsVisible = true;
                    TranslationY = -60;
                    cancellationToken = new CancellationTokenSource();
                    AnimateSpinner(cancellationToken.Token);
                    await this.TranslateTo(0, 0, 400, Easing.CubicInOut);
                }
                else
                {
                    cancellationToken?.Cancel();
                    await this.TranslateTo(0, -60, 400, Easing.CubicInOut);
                    TranslationY = 0;
                    IsVisible = false;
                }

            }
            catch (Exception ex)
            {
                //App.Logger.Report(ex);
            }
        }
        async void AnimateSpinner(CancellationToken cancellation)
        {
            try
            {
                while (!cancellation.IsCancellationRequested)
                {
                    for (int i = 1; i < 2; i++)
                    {
                        if (image.Rotation >= 360f) image.Rotation = 0;
                        await image.RotateTo(i * (360 / 1), 1000, Easing.Linear);
                    }
                }
            }
            catch (Exception ex)
            {
                //App.Logger.Report(ex, Severity.Error);
            }
        }
        #endregion
    }
}
