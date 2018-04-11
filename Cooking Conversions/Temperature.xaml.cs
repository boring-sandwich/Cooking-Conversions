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
    public partial class Temperature : PhoneApplicationPage
    {
        private bool IsInitialized = false;

        public void SetForFahrenheit()
        {
            sldTemp.Maximum = 450;
            sldTemp.Minimum = 275;
        }

        public Temperature()
        {
            InitializeComponent();
            BuildLocalizedAppBar();
            IsInitialized = true;
            SetForFahrenheit();

        }

        private void sldTemp_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!IsInitialized)
            { return; }

            double dubFahrenheit = sldTemp.Value;
            double dubCelsius;
            double dubGasMark;

            dubCelsius = FahrenheitToCelsius(dubFahrenheit);
            dubGasMark = FahrenheitToGasMark(dubFahrenheit);
            double sldNum;
            sldNum = sldTemp.Value;
            txtbFahrenheitOutput.Text = sldNum.ToString("n0");
            txtbCelsiusOutput.Text = dubCelsius.ToString("n0");

            if (dubGasMark == 0)
            {
                txtbGasMarkOutput.Text = "N/A";
            }
            txtbGasMarkOutput.Text = dubGasMark.ToString("n0");
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            sldTemp.Value--;
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            sldTemp.Value++;
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