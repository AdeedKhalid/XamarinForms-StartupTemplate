﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFStructure.Views
{
    public class MaterialSpinner : ContentView
    {
        #region Initializations
        Image image;
        #endregion

        #region Properties
        public static readonly BindableProperty IsRunningProperty = BindableProperty.Create(nameof(IsRunning), typeof(bool),
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
                Margin = new Thickness(0, -32, 0, 0);
                VerticalOptions = LayoutOptions.Start;
                HorizontalOptions = LayoutOptions.Center;
                image = new Image()
                {
                    Source = ImageSource.FromFile("activity_indicator.gif"),
                    IsAnimationPlaying = false,
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
                Content = frame;
            }
            catch (Exception)
            {
            }
        }

        private async void ToggleVisibility(bool isRunning)
        {
            try
            {
                if (isRunning)
                {
                    IsVisible = true;
                    this.image.IsAnimationPlaying = true;
                    await SetYAxisPosition(true);
                }
                else
                {
                    await SetYAxisPosition(false);
                    this.image.IsAnimationPlaying = false;
                    IsVisible = false;
                }
            }
            catch (Exception)
            {
            }
        }

        async Task SetYAxisPosition(bool isDown)
        {
            try
            {
                if (isDown)
                {
                    for (int i = 0; i <= 80; i += 4)
                    {
                        TranslationY = i;
                        if (Device.RuntimePlatform == Device.Android) await Task.Delay(1);
                        else if (Device.RuntimePlatform == Device.iOS) await Task.Delay(10);
                    }
                }
                else
                {
                    for (int i = Convert.ToInt32(TranslationY); i >= 0; i -= 4)
                    {
                        TranslationY = i;
                        if (Device.RuntimePlatform == Device.Android) await Task.Delay(1);
                        else if (Device.RuntimePlatform == Device.iOS) await Task.Delay(10);
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion
    }
}
