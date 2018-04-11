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
    public partial class Volume : PhoneApplicationPage
    {
        private bool IsInitialized = false;
        public Volume()
        {
            InitializeComponent();
            BuildLocalizedAppBar();
            IsInitialized = true;
        }

        private void sldVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!IsInitialized)
            { return; }

            double sldValue;
            sldValue = sldVolume.Value;
            double dblLiters = sldValue / 1000;

            VolumeConversions vc = new VolumeConversions();
            Utilities u = new Utilities();

            txbOutputLiters.Text = dblLiters.ToString("n2");

            double dblLiters2Quarts = vc.LitersToQuarts(dblLiters);
            if (chxVolumeRounding.IsChecked == true)
            {
                dblLiters2Quarts = u.Rounding(dblLiters2Quarts);
                txbOutputQuarts.Text = dblLiters2Quarts.ToString("n2");
            }
            else
            { 
            txbOutputQuarts.Text = dblLiters2Quarts.ToString("n2");
            }

            double dblLiters2Gallons = vc.LitersToGallons(dblLiters);

            if (chxVolumeRounding.IsChecked == true)
            {
                dblLiters2Gallons = u.Rounding(dblLiters2Gallons);
                txbOutputGallons.Text = dblLiters2Gallons.ToString("n2");
            }
            else 
            {
                txbOutputGallons.Text = dblLiters2Gallons.ToString("n2");
            }

            txbOutputMilliliters.Text = sldValue.ToString("n0");

            double dblMilliliters2Cups = vc.MillilitersToCups(sldValue);
            
            if (chxVolumeRounding.IsChecked == true)
            {
                dblMilliliters2Cups = u.Rounding(dblMilliliters2Cups);
                txbOutputCups.Text = dblMilliliters2Cups.ToString("n2");
            }
            else
            {
                txbOutputCups.Text = dblMilliliters2Cups.ToString("n2");
            }

            double dblMilliliters2Ounces = vc.MillilitersToOunces(sldValue);
            if (chxVolumeRounding.IsChecked == true)
            {
                dblMilliliters2Ounces = u.Rounding(dblMilliliters2Ounces);
                txbOutputOunces.Text = dblMilliliters2Ounces.ToString("n2");
            }
            else
            {
                txbOutputOunces.Text = dblMilliliters2Ounces.ToString("n2");
            }
        }

        private void btnVolumeMinus_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sldVolume.Value--;
        }

        private void btnVolumePlus_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sldVolume.Value++;
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