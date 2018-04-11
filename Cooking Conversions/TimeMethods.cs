using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.IsolatedStorage;
using System.Diagnostics;
using Microsoft.Phone.Shell;
using Cooking_Conversions.Resources;
using System.Globalization;
using System.Windows.Threading;
using Microsoft.Phone.Controls;

namespace Cooking_Conversions
{
    class TimeMethods
    {
        public int GetTime(ListPicker mainListPicker)
        {
            return GetTagAsTime((ListPickerItem)mainListPicker.SelectedItem);
        }
        public void SplitTime(int intTime, out int intMinutes, out int intSeconds)
        {
            intSeconds = intTime % 60;
            intMinutes = intTime - intSeconds;
        }
        public int GetTagAsTime(ListPickerItem selectedItem)
        {
            string strTag = (string)selectedItem.Tag;
            int intTag = int.Parse(strTag);
            return intTag;
        }
        public void MatchTime(int intTime, ListPicker mainListPicker)
        {
            foreach (ListPickerItem item in mainListPicker.Items)
            {
                if (intTime == GetTagAsTime(item))
                {
                    mainListPicker.SelectedItem = item;
                    break;
                }
            }
        }
        public void MatchListpicker(int intTime, ListPicker listpickerMinutes, ListPicker listPickerSeconds)
        {
            int intMinutes, intSeconds;
            SplitTime(intTime, out intMinutes, out intSeconds);
            MatchTime(intMinutes, listpickerMinutes);
            MatchTime(intSeconds, listPickerSeconds);
        }
    }
}
