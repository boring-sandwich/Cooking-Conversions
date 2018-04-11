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
    public partial class BakingPowder : PhoneApplicationPage
    {
        private bool IsInitialized = false;
        public BakingPowder()
        {
            InitializeComponent();
            BuildLocalizedAppBar();
            IsInitialized = true;
        }

        private void sldValue_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!IsInitialized)
            { return; }

            TipsConversions tc = new TipsConversions();
            Utilities u = new Utilities();
         
            //display for grams
            int intGrams = (int)sldValue.Value;
            txbOutputAllPurposeFlour.Text = sldValue.Value.ToString("n0");

            //display for cups
            int intCups = (int)sldValue.Value / 110;
            txbOutputCupsToFlour.Text = intCups.ToString("n0");

            //display for ounces
            int intOunces = (int)(sldValue.Value / 100) * 4;
            txbOutputOuncesToFlour.Text = intOunces.ToString("n0");

            //conversion for grams

            intGrams = tc.Grams2TSP(intGrams);
            txbOutputBPowder.Text = intGrams.ToString("n0");
            txbOutputSalt.Text = tc.TSPSALT((double)intGrams).ToString();

            //conversion for cups
            txbOutputCupsToBPowder.Text = intCups.ToString("n0");
            txbOutputCupsToSalt.Text = tc.TSPSALT(intCups).ToString();
            txbOutputCupsToFlour.Text = tc.TSPSALT((double)intCups).ToString();

            //conversion for ounces
            intOunces = tc.Ounces2TSP(intOunces);
            txbOutputOuncesToBPowder.Text = intOunces.ToString("n0");
            txbOutputOuncesSalt.Text = tc.TSPSALT(intOunces).ToString();
            txbOutputOuncesSalt.Text = tc.TSPSALT((double)intOunces).ToString();
        }

        private void btnBPowderMinus_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sldValue.Value--;
        }

        private void btnBPowderPlus_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sldValue.Value++;
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