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
    public partial class Weight : PhoneApplicationPage
    {
        private bool IsInitialized = false;

        public Weight()
        {
            InitializeComponent();
            BuildLocalizedAppBar();
            IsInitialized = true;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!IsInitialized)
            { return; }

            WeightConversionsFlour wcf = new WeightConversionsFlour();
            Utilities u = new Utilities();

            double sldValue01;
            sldValue01 = sldKiloWeight.Value;

            double sldValue02;
            sldValue02 = sldWeight.Value;

            if (chxRounding.IsChecked == true)
            {
                sldValue01 = u.Rounding(sldValue01);
                txbOutputKilograms.Text = sldValue01.ToString("n2");
            }
            txbOutputKilograms.Text = sldValue01.ToString("n2");

            double dblKilo2Pounds;
            if (chxRounding.IsChecked == true)
            {
                dblKilo2Pounds = wcf.KilogramsToPounds(sldValue01);
                dblKilo2Pounds = u.Rounding(dblKilo2Pounds);
                txbOutputPounds.Text = dblKilo2Pounds.ToString("n2");
            }
            else
            {
                dblKilo2Pounds = wcf.KilogramsToPounds(sldValue01);
                txbOutputPounds.Text = dblKilo2Pounds.ToString("n2");
            }

            int intGramsOutput;

            if (chxRounding.IsChecked == true)
            {
                sldValue02 = u.Rounding(sldValue02);
                intGramsOutput = (int)sldValue02;
                txbOutputGrams.Text = intGramsOutput.ToString("n0");
            }
            intGramsOutput = (int)sldValue02;
            txbOutputGrams.Text = intGramsOutput.ToString("n0");

            double dblGrams2Ounces;
            if (chxRounding.IsChecked == true)
            {
                dblGrams2Ounces = wcf.GramsToOunces(sldValue02);
                dblGrams2Ounces = u.Rounding(dblGrams2Ounces);
                txbOutputOunces.Text = dblGrams2Ounces.ToString("n2");
            }
            else
            {
                dblGrams2Ounces = wcf.GramsToOunces(sldValue02);
                txbOutputOunces.Text = dblGrams2Ounces.ToString("n2");
            }

            double dblGrams2Pounds;
            if (chxRounding.IsChecked == true)
            {
                dblGrams2Pounds = wcf.GramsToPounds(sldValue02);
                dblGrams2Pounds = u.Rounding(dblGrams2Pounds);
                txbOutputPoundsGrams.Text = dblGrams2Pounds.ToString("n2");
            }
            else
            {
                dblGrams2Pounds = wcf.GramsToPounds(sldValue02);
                txbOutputPoundsGrams.Text = dblGrams2Pounds.ToString("n2");
            }

            double dblGrams2Cups;
            if (chxRounding.IsChecked == true)
            {
                dblGrams2Cups = wcf.GramsToCups(sldValue02);
                dblGrams2Cups = u.Rounding(dblGrams2Cups);
                txbOutputCups.Text = dblGrams2Cups.ToString("n2");
            }
            else
            {
                dblGrams2Cups = wcf.GramsToCups(sldValue02);
                txbOutputCups.Text = dblGrams2Cups.ToString("n2");
            }
        }

        private void sldButter_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            WeightConversionButter wcb = new WeightConversionButter();
            
            //display slider for grams
            txbOutputGramsButter.Text = sldButter.Value.ToString("n0");

            //display for cups
            txbOutputCupsButter.Text = wcb.GramsToCups(sldButter.Value).ToString("n2");

            //display for ounces
            txbOutputOuncesButter.Text = wcb.GramsToOunces(sldButter.Value).ToString("n2");

            //display for pounds
            txbOutputPoundButter.Text = wcb.GramsToPounds(sldButter.Value).ToString("n2");
        }

        private void sldOil_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            WeightConversionOil wco = new WeightConversionOil();

            //display slider for grams
            txbOutputGramsOil.Text = sldOil.Value.ToString("n0");

            //display for cups
            txbOutputCupsOil.Text = wco.GramsToCups(sldOil.Value).ToString("n2");

            //display for ounces
            txbOutputOuncesOil.Text = wco.GramsToOunces(sldOil.Value).ToString("n2");
        }

        private void sldSugar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            WeightConversionsSugar wcs = new WeightConversionsSugar();

            //display slider for grams
            txbOutputGramsSugar.Text = sldSugar.Value.ToString("n0");

            //display for cups
            txbOutputCupsSugar.Text = wcs.GramsToCups(sldSugar.Value).ToString("n2");

            //display for ounces
            txbOutputOuncesSugar.Text = wcs.GramsToOunces(sldSugar.Value).ToString("n2");

            //display for pounds
            txbOutputPoundSugar.Text = wcs.GramsToPounds(sldSugar.Value).ToString("n2");
        }

        private void btnOilMinus_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sldOil.Value--;
        }

        private void btnOilPlus_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sldOil.Value++;
        }

        private void btnButterMinus_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sldButter.Value--;
        }

        private void btnButterPlus_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sldButter.Value++;
        }
        private void btnSugarMinus_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sldSugar.Value--;
        }
        private void btnSugarPlus_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sldSugar.Value++;
        }

        private void btnFlour02Plus_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sldWeight.Value++;
        }
        private void btnFlour02Minus_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sldWeight.Value--;
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