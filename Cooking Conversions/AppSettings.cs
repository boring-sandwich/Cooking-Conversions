using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.IsolatedStorage;
using System.Diagnostics;
using Microsoft.Phone.Shell;

namespace Cooking_Conversions
{
    class AppSettings
    {
        //our settings
        IsolatedStorageSettings settings;

        //the key names of the settings.
        const string SoftBoiledKeyName = "SoftBoiled";
        const string HardBoiledKeyName = "HardBoiled";
        const string PoachedKeyName = "Poached";
        const string RadioButtonHardBoiledKeyName = "RadioButtonHardBoiled";
        const string RadioButtonSoftBoiledKeyName = "RadioButtonSoftBoiled";
        const string RadioButtonSoftCustomBoiledKeyName = "RadioButtonSoftCustomBoiled";
        const string RadioButtonHardCustomBoiledKeyName = "RadioButtonHardCustomBoiled";
        const string RadioButtonNormalPoachedKeyName = "RadioButtonNormalPoached";
        const string RadioButtonCustomPoachedKeyName = "RadioButtonCustomPoached";
        const string ToggleSwitchVibrationKeyName = "ToggleSwitchVibration";
        const string ToggleSwitchSoundKeyName = "ToggleSwitchSound";

        //the defalut value of the settings.
        const int SoftBoiledDefault = 120;
        const int HardBoiledDefault = 480;
        const int PoachedDefault = 180;
        const bool RadioButtonHardBoiledDefault = false;
        const bool RadioButtonSoftBoiledDefault = true;       
        const bool RadioButtonSoftCustomBoiledDefault = false;
        const bool RadioButtonHardCustomBoiledDefault = false;
        const bool RadioButtonNormalPoachedDefault = false;
        const bool RadioButtonCustomPoachedDefault = false;
        const bool ToggleSwitchVibrationDefault = false;
        const bool ToggleSwitchSoundDefault = false;

        //constructor that gets the application settings.

        public AppSettings()
        {
            //get the settings for this application
            settings = IsolatedStorageSettings.ApplicationSettings;
        }

        //update a setting value for the application. is the seeting does not exist then add the setting.
        public bool AddOrUpdateValue(string Key, Object value)
        {
            bool valueChanged = false;
            if (settings.Contains(Key))
            {
                if (settings[Key] != value)
                {
                    settings[Key] = value;
                    valueChanged = true;
                }
            }
            else
            {
                settings.Add(Key, value);
                valueChanged = true;
            }
            return valueChanged;
        }
        //get the current value of the setting and if it does not exist, set the value to the default setting.
        public T GetValueOrDefault<T>(string Key, T defaultValue)
        {
            T value;
            if (settings.Contains(Key))
            {
                value = (T)settings[Key];
            }
            else
            {
                value = defaultValue;
            }
            return value;
        }
        //save the settings
        public void Save()
        {
            settings.Save();
        }
        //property to get and set the variables.
        public int SoftBoiled
        {
            get
            {
                return GetValueOrDefault<int>(SoftBoiledKeyName, SoftBoiledDefault);
            }
            set
            {
                if (AddOrUpdateValue(SoftBoiledKeyName, value))
                {
                    Save();
                }
            }
        }
        public int HardBoiled
        {
            get
            {
                return GetValueOrDefault<int>(HardBoiledKeyName, HardBoiledDefault);
            }
            set
            {
                if (AddOrUpdateValue(HardBoiledKeyName, value))
                {
                    Save();
                }
            }
        }
        public int Poached
        {
            get
            {
                return GetValueOrDefault<int>(PoachedKeyName, PoachedDefault);
            }
            set
            {
                if (AddOrUpdateValue(PoachedKeyName, value))
                {
                    Save();
                }
            }
        }
        public bool RadioButtonHardBoiled
        {
            get
            {
                return GetValueOrDefault<bool>(RadioButtonHardBoiledKeyName, RadioButtonHardBoiledDefault);
            }
            set
            {
                if (AddOrUpdateValue(RadioButtonHardBoiledKeyName, value))
                {
                    Save();
                }
            }
        }
        public bool RadioButtonSoftBoiled
        {
            get
            {
                return GetValueOrDefault<bool>(RadioButtonSoftBoiledKeyName, RadioButtonSoftBoiledDefault);
            }
            set
            {
                if (AddOrUpdateValue(RadioButtonSoftBoiledKeyName, value))
                {
                    Save();
                }
            }
        }
        public bool RadioButtonSoftCustomBoiled
        {
            get
            {
                return GetValueOrDefault<bool>(RadioButtonSoftCustomBoiledKeyName, RadioButtonSoftCustomBoiledDefault);
            }
            set
            {
                if (AddOrUpdateValue(RadioButtonSoftCustomBoiledKeyName, value))
                {
                    Save();
                }
            }
        }
        public bool RadioButtonHardCustomBoiled
        {
            get
            {
                return GetValueOrDefault<bool>(RadioButtonHardCustomBoiledKeyName, RadioButtonHardCustomBoiledDefault);
            }
            set
            {
                if (AddOrUpdateValue(RadioButtonHardCustomBoiledKeyName, value))
                {
                    Save();
                }
            }
        }
        public bool RadioButtonNormalPoached
        {
            get
            {
                return GetValueOrDefault<bool>(RadioButtonNormalPoachedKeyName, RadioButtonNormalPoachedDefault);
            }
            set
            {
                if (AddOrUpdateValue(RadioButtonNormalPoachedKeyName, value))
                {
                    Save();
                }
            }
        }
        public bool RadioButtonCustomPoached
        {
            get
            {
                return GetValueOrDefault<bool>(RadioButtonCustomPoachedKeyName, RadioButtonCustomPoachedDefault);
            }
            set
            {
                if (AddOrUpdateValue(RadioButtonCustomPoachedKeyName, value))
                {
                    Save();
                }
            }
        }
        public bool ToggleSwitchVibration
        {
            get
            {
                return GetValueOrDefault<bool>(ToggleSwitchVibrationKeyName, ToggleSwitchVibrationDefault);
            }
            set
            {
                if(AddOrUpdateValue(ToggleSwitchVibrationKeyName, value))
                {
                    Save();
                }
            }
        }
        public bool ToggleSwitchSound
        {
            get
            {
                return GetValueOrDefault<bool>(ToggleSwitchSoundKeyName, ToggleSwitchSoundDefault);
            }
            set
            {
                if(AddOrUpdateValue(ToggleSwitchSoundKeyName, value))
                {
                    Save();
                }
            }
        }
    }
}
