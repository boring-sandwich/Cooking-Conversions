using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Cooking_Conversions.Resources;
using System.Globalization;
using System.Windows.Threading;
using Microsoft.Devices;

namespace Cooking_Conversions
{
    public partial class EggSettings : PhoneApplicationPage
    {
        private bool IsInitialized = false;
        AppSettings settings = new AppSettings();
        public EggSettings()
        {
            InitializeComponent();
            BuildLocalizedAppBar();
            GetSettings();
            ThreadDateTimeConverter tc = new ThreadDateTimeConverter();
            IsInitialized = true;
        }

        private void SaveSettings()
        {
            TimeMethods tm = new TimeMethods();
            settings.SoftBoiled = tm.GetTime(timeSoftBoiledMinutes) + tm.GetTime(timeSoftBoiledSeconds);
            settings.HardBoiled = tm.GetTime(timeHardBoiledMinutes) + tm.GetTime(timeHardBoiledSeconds);
            settings.Poached = tm.GetTime(timePoachedMinutes) + tm.GetTime(timePoachedSeconds);
            settings.ToggleSwitchVibration = togVibrationSetting.IsChecked.Value;
            settings.ToggleSwitchSound = togSoundSetting.IsChecked.Value;


        }
        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            SaveSettings();
        }

        private void GetSettings()
        {
            TimeMethods tm = new TimeMethods();
            tm.MatchListpicker(settings.SoftBoiled, timeSoftBoiledMinutes, timeSoftBoiledSeconds);
            tm.MatchListpicker(settings.HardBoiled, timeHardBoiledMinutes, timeHardBoiledSeconds);
            tm.MatchListpicker(settings.Poached, timePoachedMinutes, timePoachedSeconds);
            togVibrationSetting.IsChecked = settings.ToggleSwitchVibration;
            togSoundSetting.IsChecked = settings.ToggleSwitchSound;
        }
        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            SaveSettings();
            base.OnNavigatingFrom(e);
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            GetSettings();
            base.OnNavigatedTo(e);
        }

        private void BuildLocalizedAppBar()
        {
            ApplicationBar = new ApplicationBar();
            ApplicationBar.Mode = ApplicationBarMode.Minimized;

            ApplicationBarMenuItem appBarMenuItemAbout = new ApplicationBarMenuItem(AppResources.AppBarMenuItemAbout);
            ApplicationBar.MenuItems.Add(appBarMenuItemAbout);
            appBarMenuItemAbout.Click += appBarMenuItemAbout_Click;

            ApplicationBarMenuItem appBarMenuItemDisclaimer = new ApplicationBarMenuItem(AppResources.AppBarMenuItemDisclaimer);
            ApplicationBar.MenuItems.Add(appBarMenuItemDisclaimer);
            appBarMenuItemDisclaimer.Click += appBarMenuItemDisclaimer_Click;

            ApplicationBarIconButton appBarButtonSettings = new ApplicationBarIconButton(new Uri("/Assets/feature.settings.png", UriKind.Relative));
            appBarButtonSettings.Text = AppResources.AppBarButtonSettings;
            ApplicationBar.Buttons.Add(appBarButtonSettings);
            appBarButtonSettings.Click += appBarButtonSettings_Click;

            ApplicationBarIconButton appBarButtonHome = new ApplicationBarIconButton(new Uri("Assets/home.png", UriKind.Relative));
            appBarButtonHome.Text = AppResources.AppBarButtonHome;
            ApplicationBar.Buttons.Add(appBarButtonHome);
            appBarButtonHome.Click += appBarButtonHome_Click;
        }

        void appBarMenuItemDisclaimer_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Disclaimer.xaml", UriKind.Relative));
        }

        void appBarButtonHome_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        void appBarButtonSettings_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/EggSettings.xaml", UriKind.Relative));
        }

        void appBarMenuItemAbout_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }
    }
}