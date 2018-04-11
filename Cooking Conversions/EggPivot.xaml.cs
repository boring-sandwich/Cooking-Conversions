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
using System.Windows.Threading;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;

namespace Cooking_Conversions.Eggies
{
    public partial class EggPivot : PhoneApplicationPage
    {
        private bool IsInitialized = false;
        AppSettings settings = new AppSettings();
        //boiled bits and bobs
        public const int boiledHard = 540;
        static int anyTime;
        static System.Threading.Timer timerBoiled;
        public const int boiledSoft = 210;
        public int softBoiledCustom;
        public int hardBoiledCustom;
        public static bool isTimerOn = false;
        //poached egg bits and bobs
        public int poachedCustom;
        public const int poached = 180;
        public bool isSoftBoiledVisible = false;
        public bool isHardBoiledVisible = false;
        public bool isPoachedVisible = false;

        public EggPivot()
        {
            InitializeComponent();
            BuildLocalizedAppBar();
            RestoreSavedContents();
            SoftBoiledInvisible();
            HardBoiledInvisible();
            PoachedInvisible();
            AllInstructionsInvisible();
            DisplayFriedEggInfo();
            ConvertEggSelectionToTime();
            IsInitialized = true;
        }
        //callback method for the timer. The only paramter is the object you passed when you created the timer object.
        public static void ProcessTimerEvent(object obj)
        {
            isTimerOn = true;
            EggPivot eggTime = (EggPivot)obj;
            --anyTime;
            //If the countdown is complete make a sound and/or vibrate depending on settings.
            if (anyTime == 0)
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    eggTime.btnBoiledReset.Content = "go";
                });
                
                StopTimer();
                VibrationSound();
            }

            Deployment.Current.Dispatcher.BeginInvoke(() =>
             {
                 eggTime.txbBoiledTimer.Text = string.Format("{0}:{1:0#}", anyTime / 60, anyTime % 60);
             });
                }
        public static void VibrationSound()
        {
            //consider writing the bit that makes the text flash
        Microsoft.Xna.Framework.Audio.SoundEffect sound = SoundEffect.FromStream(TitleContainer.OpenStream("Assets/sound.wav"));

            AppSettings settings = new AppSettings();
            if (settings.ToggleSwitchVibration )
            {
                Microsoft.Devices.VibrateController testVibrateController = Microsoft.Devices.VibrateController.Default;
            testVibrateController.Start(TimeSpan.FromSeconds(3));
            }
            if (settings.ToggleSwitchSound)
            {
                FrameworkDispatcher.Update();
                sound.Play();
            }
        }
        
        private static void StopTimer()
        {
            timerBoiled.Dispose();
            isTimerOn = false;              
        }

        private void StartTimer()
        {
            //create the timer for the callback method
            if (!isTimerOn)
            {
                ConvertEggSelectionToTime();
                System.Threading.TimerCallback cb = new System.Threading.TimerCallback(ProcessTimerEvent);
                //Create the object for the timer.
                timerBoiled = new System.Threading.Timer(cb, this, 0, 1000);
            }
        }

        private void ConvertEggSelectionToTime()
        {
            if (radPoachedStandard.IsChecked == true)
                anyTime = poached;
            else if (radPoachedCustom.IsChecked == true)
                anyTime = poachedCustom;
            else if (radBoiledHard.IsChecked == true)
                anyTime = boiledHard;
            else if (radBoiledSoft.IsChecked == true)
                anyTime = boiledSoft;
            else if (radHardBoiledCustom.IsChecked == true)
                anyTime = hardBoiledCustom;
            else
                anyTime = softBoiledCustom;
        }
        private void radioEggTimerSelection_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if(isTimerOn)
            {
                return;
            }
            else if (!isTimerOn)
            {
                ConvertEggSelectionToTime();
                txbBoiledTimer.Text = string.Format(string.Format("{0}:{1:0#}", anyTime / 60, anyTime % 60));
            }
        }
        private void btnBoiledReset_Click(object sender, RoutedEventArgs e)
        {
            if (!isTimerOn)
            {
                MessageBox.Show("You may lose your timer if you navigate away from the page.", "advice", MessageBoxButton.OK);
                StartTimer();
                btnBoiledReset.Content = "stop";
            }
            else
            { 
                StopTimer();
                btnBoiledReset.Content = "go";
                ConvertEggSelectionToTime();
                txbBoiledTimer.Text = string.Format(string.Format("{0}:{1:0#}", anyTime / 60, anyTime % 60));
            }
        }
        public void RestoreSavedContents()
        {
            radSoftBoiledCustom.IsChecked = settings.RadioButtonSoftCustomBoiled;
            radHardBoiledCustom.IsChecked = settings.RadioButtonHardCustomBoiled;
            radBoiledHard.IsChecked = settings.RadioButtonHardBoiled;
            radBoiledSoft.IsChecked = settings.RadioButtonSoftBoiled;
            radPoachedStandard.IsChecked = settings.RadioButtonNormalPoached;
            radPoachedCustom.IsChecked = settings.RadioButtonCustomPoached;
            //boiled custom timer get the time
            softBoiledCustom = settings.SoftBoiled;
            hardBoiledCustom = settings.HardBoiled;
            //poached custom timer get the time
            poachedCustom = settings.Poached;
        }
        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            settings.RadioButtonSoftCustomBoiled = radSoftBoiledCustom.IsChecked.Value;
            settings.RadioButtonHardCustomBoiled = radHardBoiledCustom.IsChecked.Value;
            settings.RadioButtonHardBoiled = radBoiledHard.IsChecked.Value;
            settings.RadioButtonSoftBoiled = radBoiledSoft.IsChecked.Value;
            settings.RadioButtonNormalPoached = radPoachedStandard.IsChecked.Value;
            settings.RadioButtonCustomPoached = radPoachedCustom.IsChecked.Value;
            PhoneApplicationService phoneAppService = PhoneApplicationService.Current;
            phoneAppService.UserIdleDetectionMode = IdleDetectionMode.Enabled;
            base.OnNavigatingFrom(e);
        }
        public void DisplayFriedEggInfo()
        {
            if (txbBoiledDescription.Visibility == System.Windows.Visibility.Visible)
            {
                txbBoiledDescription.Text = "Use room temperature eggs otherwise there is the potential of the shell cracking." + Environment.NewLine
                    + "**Soft Boiled (medium eggs)**" + Environment.NewLine
                    + "Lower the egg into gently boiling water and then start the timer for soft boiled egg. (Add an extra 30 seconds for a large egg.)" + Environment.NewLine
                    + "**Hard Boiled (medium eggs)**" + Environment.NewLine
                    + "Place the egg in cold water and bring the pan to a gentle boil." + Environment.NewLine
                    + "Start the hard boiled timer. (Add an extra minute for a large egg.)" + Environment.NewLine
                    + "The longer you leave the egg to gently boil, the firmer the egg will be." + Environment.NewLine
                    + "When cooked, cool the egg by placing it in a boil of cold water. Peal when ready.";
            }
            else if (txbFriedDescription.Visibility == System.Windows.Visibility.Visible)
            {            
                txbFriedDescription.Text = "On a medium heat and using a non-stick pan, coated in oil, do the following:" + Environment.NewLine
                    + "**Easy**" + Environment.NewLine 
                    + "Also known as dippy eggs." + Environment.NewLine
                    + "Cook the egg on both sides. Egg white is fully cooked; the yolk is runny." + Environment.NewLine
                    + "**Medium**" + Environment.NewLine
                    + "Cook the egg on both sides. The yolk should be fully cooked and hard." + Environment.NewLine
                    + "**Hard**" + Environment.NewLine
                    + "Cook the egg on both sides. The yolk should be fully cooked and hard." + Environment.NewLine
                    + "**Sunny**" + Environment.NewLine
                    + "Cook on one side only. Egg white is set; the yolk is liquid to runny.";
            }
            else if (txbPoachedDescription.Visibility == System.Windows.Visibility.Visible)
            {
                txbPoachedDescription.Text = "Use fresh eggs only!" + Environment.NewLine
                    + "Use a shallow pan with simmering water." + Environment.NewLine
                    + "Swirl the water and crack your egg into the swirl or use a poacher and lower your egg into the water." + Environment.NewLine
                    + "Carefully keep the water moving so you do not break the egg (not required if using poacher)." + Environment.NewLine
                    + "For medium firm yolks allow 3 minutes to cook." + Environment.NewLine
                    + "Please note that the residual heat will continue to cook the eggs.";
            }
            else if (txbScrambledDescription.Visibility == System.Windows.Visibility.Visible)
            {
                txbScrambledDescription.Text = "Use a non-stick pan on a low heat and melt a nob of butter." + Environment.NewLine
                    + "Crack eggs in jug and add a splash of milk and then whisk." + Environment.NewLine
                    + "Once the butter has melted add the egsg to the pan." + Environment.NewLine
                    + "Use a wooden spoon and constantly, but slowly, stir for 4/5 minutes or so, until the eggs set into curds." + Environment.NewLine
                    + "Remove from the heat just before the eggs are cooked. The residual heat will finish the eggs off.";
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string thePageNum;
            NavigationContext.QueryString.TryGetValue("goto", out thePageNum);
            myPivot.SelectedIndex = Convert.ToInt32(thePageNum);
            PhoneApplicationService phoneAppService = PhoneApplicationService.Current;
            phoneAppService.UserIdleDetectionMode = IdleDetectionMode.Disabled;
            RestoreSavedContents();
            ConvertEggSelectionToTime();
            txbBoiledTimer.Text = string.Format(string.Format("{0}:{1:0#}", anyTime / 60, anyTime % 60));
            base.OnNavigatedTo(e);
        }
        private void BuildLocalizedAppBar()
        {
            ApplicationBar = new ApplicationBar();
            ApplicationBar.Mode = ApplicationBarMode.Minimized;

            ApplicationBarMenuItem appBarMenuItemAbout = new ApplicationBarMenuItem(AppResources.AppBarMenuItemAbout);
            ApplicationBar.MenuItems.Add(appBarMenuItemAbout);
            appBarMenuItemAbout.Click += appBarMenuItemAbout_Click;

            ApplicationBarIconButton appBarButtonSettings = new ApplicationBarIconButton(new Uri("/Assets/feature.settings.png", UriKind.Relative));
            appBarButtonSettings.Text = AppResources.AppBarButtonSettings;
            ApplicationBar.Buttons.Add(appBarButtonSettings);
            appBarButtonSettings.Click += appBarButtonSettings_Click;

            ApplicationBarIconButton appBarButtonHome = new ApplicationBarIconButton(new Uri("Assets/home.png", UriKind.Relative));
            appBarButtonHome.Text = AppResources.AppBarButtonHome;
            ApplicationBar.Buttons.Add(appBarButtonHome);
            appBarButtonHome.Click += appBarButtonHome_Click;
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
        private void txbSoftBoiled_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (!isSoftBoiledVisible)
            {
                SoftBoiledVisible();
                HardBoiledInvisible();
                PoachedInvisible();
            }
            else
            {
                SoftBoiledInvisible();
            }
        }
        private void txbHardBoiled_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (!isHardBoiledVisible)
            {
                SoftBoiledInvisible();
                HardBoiledVisible();
                PoachedInvisible();
            }
            else
            {
                HardBoiledInvisible();
            }
        }
        private void txbPoachedTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (!isPoachedVisible)
            {
                SoftBoiledInvisible();
                HardBoiledInvisible();
                PoachedVisible();
            }
            else
            {
                PoachedInvisible();
            }
        }

        private void PoachedInvisible()
        {
            radPoachedStandard.Visibility = System.Windows.Visibility.Collapsed;
            radPoachedCustom.Visibility = System.Windows.Visibility.Collapsed;
            isPoachedVisible = false;
        }

        private void PoachedVisible()
        {
            radPoachedStandard.Visibility = System.Windows.Visibility.Visible;
            radPoachedCustom.Visibility = System.Windows.Visibility.Visible;
            isPoachedVisible = true;
        }
        private void SoftBoiledInvisible()
        {
            radBoiledSoft.Visibility = System.Windows.Visibility.Collapsed;
            radSoftBoiledCustom.Visibility = System.Windows.Visibility.Collapsed;
            isSoftBoiledVisible = false;
        }

        private void SoftBoiledVisible()
        {
            radBoiledSoft.Visibility = System.Windows.Visibility.Visible;
            radSoftBoiledCustom.Visibility = System.Windows.Visibility.Visible;
            isSoftBoiledVisible = true;
        }
        private void HardBoiledInvisible()
        {
            radBoiledHard.Visibility = System.Windows.Visibility.Collapsed;
            radHardBoiledCustom.Visibility = System.Windows.Visibility.Collapsed;
            isSoftBoiledVisible = false;
        }

        private void HardBoiledVisible()
        {
            radBoiledHard.Visibility = System.Windows.Visibility.Visible;
            radHardBoiledCustom.Visibility = System.Windows.Visibility.Visible;
            isSoftBoiledVisible = true;
        }
        private void AllInstructionsInvisible()
         {
             txbBoiledDescription.Visibility = System.Windows.Visibility.Collapsed;
             txbFriedDescription.Visibility = System.Windows.Visibility.Collapsed;
             txbPoachedDescription.Visibility = System.Windows.Visibility.Collapsed;
             txbScrambledDescription.Visibility = System.Windows.Visibility.Collapsed;
         }

        private void txbBoiledInstructionsVisibility_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (txbBoiledDescription.Visibility == System.Windows.Visibility.Visible)
            {
                AllInstructionsInvisible();
                return;
            }

            AllInstructionsInvisible();
            txbBoiledDescription.Visibility = System.Windows.Visibility.Visible;
            DisplayFriedEggInfo();
        }
        private void txbFriedInstructionsVisibility_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (txbFriedDescription.Visibility == System.Windows.Visibility.Visible)
            {
                AllInstructionsInvisible();
                return;
            }
            AllInstructionsInvisible();
            txbFriedDescription.Visibility = System.Windows.Visibility.Visible;
            DisplayFriedEggInfo();
        }
        private void txbPoachedInstructionsVisibility_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (txbPoachedDescription.Visibility == System.Windows.Visibility.Visible)
            {
                AllInstructionsInvisible();
                return;
            }
            AllInstructionsInvisible();
            txbPoachedDescription.Visibility = System.Windows.Visibility.Visible;
            DisplayFriedEggInfo();
        }
        private void txbScrambledInstructionsVisibility_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (txbScrambledDescription.Visibility == System.Windows.Visibility.Visible)
            {
                AllInstructionsInvisible();
                return;
            }
            AllInstructionsInvisible();
            txbScrambledDescription.Visibility = System.Windows.Visibility.Visible;
            DisplayFriedEggInfo();
        }
    }
}