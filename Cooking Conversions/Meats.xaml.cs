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
    public partial class Meats : PhoneApplicationPage
    {
        private bool IsInitialized = false;
        public Meats()
        {
            InitializeComponent();
            BuildLocalizedAppBar();
            ChickenTipsInvisible();
            IsInitialized = true;
        }

        private void ChickenTipsInvisible()
        {
            //make things invisible here for chicken tips
            txbChickenCooking.Visibility = System.Windows.Visibility.Collapsed;
            txbChickenCooked01.Visibility = System.Windows.Visibility.Collapsed;
            txbChickenCooked02.Visibility = System.Windows.Visibility.Collapsed;

        }
        public void ChickenCooking_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (txbChickenCooking.Visibility == System.Windows.Visibility.Collapsed)
            {
                txbChickenCooking.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                ChickenTipsInvisible();
            }
        }
        public void ChickenCooked_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (txbChickenCooked01.Visibility == System.Windows.Visibility.Collapsed)
            {
                txbChickenCooked01.Visibility = System.Windows.Visibility.Visible;
                txbChickenCooked02.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                ChickenTipsInvisible();
            }
        }
        private void sldMeatsChicken_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!IsInitialized)
            { return; }

            double sldValue, sldValue01;
            int intValue, intValue01;
            sldValue = sldMeatsChicken.Value;
            txbChickenWeightOutput.Text = sldValue.ToString("n2") + "/" + (sldValue / 2.2046).ToString("n2");
            sldValue = sldMeatsChicken.Value * 22;
            sldValue01 = sldValue;
            intValue = (int)sldValue / 60;
            intValue01 = (int)sldValue01 % 60;
            txbChickenTimeOutput.Text = intValue.ToString() + ":" + intValue01.ToString(); 
        }
        private void btnChickenMinus_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sldMeatsChicken.Value = sldMeatsChicken.Value - 0.25;
        }
        private void btnChickenPlus_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            sldMeatsChicken.Value = sldMeatsChicken.Value + 0.25;
        }
        //Navigation below
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string thePageNum;
            NavigationContext.QueryString.TryGetValue("goto", out thePageNum);
            myPivot.SelectedIndex = Convert.ToInt32(thePageNum);
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