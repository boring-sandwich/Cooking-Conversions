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
    public partial class Measurements : PhoneApplicationPage
    {
        private bool IsInitialized = false;
        public Measurements()
        {
            InitializeComponent();
            BuildLocalizedAppBar();
            IsInitialized = true;
        }

        private void sldMeasurements_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!IsInitialized)
            { return; }

            MeasurementConversions mc = new MeasurementConversions();

            double sldValue;
            sldValue = sldMeasurements.Value;

            double dblMeters = sldValue / 100;
            txbOutputMeters.Text = dblMeters.ToString("n2");

            double dblFeet = mc.Meters2Feet(dblMeters);
            txbOutputFeet.Text = dblFeet.ToString("n2");

            txbOutputCentimeters.Text = sldValue.ToString("n2");

            double dblInches1 = mc.Centimeters2Inches(sldValue);
            txbOutputInches.Text = dblInches1.ToString("n2");

            double dblMillimeters = sldValue * 10;
            txbOutputMillimeters.Text = dblMillimeters.ToString("n0");

            double dblInches2 = mc.Millimeters2Inches(sldValue);
            txbOutputInches2.Text = dblInches2.ToString("n2");

        }

        private void btnMesurementMinus_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sldMeasurements.Value--;
        }

        private void btnMeasurementPlus_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sldMeasurements.Value++;
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