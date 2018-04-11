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

namespace Cooking_Conversions
{
    public partial class MainPage : PhoneApplicationPage
    {
        private bool IsInitialized = false;
        public bool IsInvisibleEggs = true;
        public bool IsInvisibleMeats = true;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            BuildLocalizedApplicationBar();
            MakeInvisibleEggs();
            //MakeInvisibleMeats();
            IsInitialized = true;
        }
        //public void MakeVisibleMeats()
        //{
        //    txbBeef.Visibility = System.Windows.Visibility.Visible;
        //    txbLamb.Visibility = System.Windows.Visibility.Visible;
        //    txbPork.Visibility = System.Windows.Visibility.Visible;
        //    txbPoultry.Visibility = System.Windows.Visibility.Visible;
        //    IsInvisibleMeats = false;
        //}
        //public void MakeInvisibleMeats()
        //{
        //    txbBeef.Visibility = System.Windows.Visibility.Collapsed;
        //    txbLamb.Visibility = System.Windows.Visibility.Collapsed;
        //    txbPork.Visibility = System.Windows.Visibility.Collapsed;
        //    txbPoultry.Visibility = System.Windows.Visibility.Collapsed;
        //    IsInvisibleMeats = true;
        //}
        public void MakeVisibleEggs()
        {
            txbTimer.Visibility = System.Windows.Visibility.Visible;
            txbTechniques.Visibility = System.Windows.Visibility.Visible;
            txbTips.Visibility = System.Windows.Visibility.Visible;
            IsInvisibleEggs = false;
        }
        public void MakeInvisibleEggs()
        {
            txbTimer.Visibility = System.Windows.Visibility.Collapsed;
            txbTechniques.Visibility = System.Windows.Visibility.Collapsed;
            txbTips.Visibility = System.Windows.Visibility.Collapsed;
            IsInvisibleEggs = true;
        }
        //private void txbBeef_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        //{
        //    NavigationService.Navigate(new Uri("/Beef.xaml", UriKind.Relative));
        //}
        //private void txbPoultry_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        //{
        //    NavigationService.Navigate(new Uri("/Meats.xaml", UriKind.Relative));
        //}
        //private void txbPork_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        //{
        //    NavigationService.Navigate(new Uri("/pork.xaml", UriKind.Relative));
        //}
        //private void txbLamb_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        //{
        //    NavigationService.Navigate(new Uri("/lamb.xaml", UriKind.Relative));
        //}
        private void txtbTemperature_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Temperature.xaml", UriKind.Relative));
        }

        private void txtbWeight_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Weight.xaml", UriKind.Relative));
        }

        private void txtbVolume_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Volume.xaml", UriKind.Relative));
        }

        private void txtbMeasurements_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Measurements.xaml", UriKind.Relative));
        }

        private void txtbBakingPowder_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/BakingPowder.xaml", UriKind.Relative));
        }

        private void txbTimerEgg_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/EggPivot.xaml?goto=0", UriKind.Relative));
        }
        private void txbTechniques_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/EggPivot.xaml?goto=1", UriKind.Relative));
        }
        private void txbTipsEgg_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/EggPivot.xaml?goto=2", UriKind.Relative));
        }

        private void txtbEggs_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (IsInvisibleEggs)
            {
                MakeVisibleEggs();
            }
            else
            {
                MakeInvisibleEggs();
            }
        }

        //private void txbMeats_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        //{
        //    if (IsInvisibleMeats)
        //    {
        //        MakeVisibleMeats();
        //    }
        //    else
        //    {
        //        MakeInvisibleMeats();
        //    }
        //}

        private void BuildLocalizedApplicationBar()
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

        private void appBarMenuItemAbout_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }
    }
}