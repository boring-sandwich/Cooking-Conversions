using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
using Cooking_Conversions.Resources;

namespace Cooking_Conversions
{
    public partial class About : PhoneApplicationPage
    {
        private bool IsInitialized = false;
        public About()
        {
            InitializeComponent();
            BuildLocalizedApplicationBar();
            IsInitialized = true;
        }
        private void txbMoreApps_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ShowAllApps();
        }

        private static void ShowAllApps()
        {
            MarketplaceSearchTask marketplaceSearchTask = new MarketplaceSearchTask();

            marketplaceSearchTask.SearchTerms = "geekypanda";
            marketplaceSearchTask.Show();
        }

        private void txbRateApp_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();

            marketplaceReviewTask.Show();
        }

        private void txbShareApp_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ShareLinkTask shareLinkTask = new ShareLinkTask();

            shareLinkTask.Title = "In Case of Emergency";
            shareLinkTask.LinkUri = new Uri("http://www.windowsphone.com/en-us/store/app/cooking-conversions/75433e23-a095-42b9-b948-862161b28c4a", UriKind.Absolute);
            shareLinkTask.Message = "Here is a great cooking conversion app for your Windows Phone.";

            shareLinkTask.Show();
        }

        private void imgLogo_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            ShowAllApps();
        }

        private void imgAppIcon_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MarketplaceDetailTask marketplaceDetailTask = new MarketplaceDetailTask();

            marketplaceDetailTask.ContentIdentifier = "75433e23-a095-42b9-b948-862161b28c4a";
            marketplaceDetailTask.Show();
        }
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