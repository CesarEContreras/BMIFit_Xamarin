using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BMIFit.Services;
using BMIFit.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using BMIFit.Helpers;

namespace BMIFit
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            AppCenter.Start($"android={Settings.Instance.AppCenterTokenAndroid};" +
                  $"ios={Settings.Instance.AppCenterTokenIOS}",
                  typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
