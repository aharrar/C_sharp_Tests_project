using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Globalization;
using BE;
using BL;

namespace PLWPF
{
    ////////////////////////////////Converters/////////////////////////////

    /*public class boolCheckbox : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool b = (bool)value;
            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            CheckBox c = (CheckBox)value;
            bool b = new bool();
            if (c.IsChecked == true)
            { b = true; }
            else
            { b = false; }
            return b;
        }
    }*/
    public class bool2dimListDays : IValueConverter// Converter: adapt bool[,] and list<worksday> for bind
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool[,] w = (bool[,])value;
            List<work_days> listsDays = new List<work_days>();
            for (int i = 0; i < 7; i++)
            {
                listsDays.Add(new work_days(((Enum.GetValues(typeof(DayWeek))).GetValue(i)).ToString()));
                listsDays[i].F10T11 = w[i, 0];
                listsDays[i].F11T12 = w[i, 1];
                listsDays[i].F12T13 = w[i, 2];
                listsDays[i].F13T14 = w[i, 3];
                listsDays[i].F14T15 = w[i, 4];
                listsDays[i].F15T16 = w[i, 5];
                listsDays[i].F16T17 = w[i, 6];
                listsDays[i].F17T18 = w[i, 7];
                listsDays[i].F18T19 = w[i, 8];
                listsDays[i].F19T20 = w[i, 9];
            }

            return listsDays;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            List<work_days> listsDays = (List<work_days>)value;
            bool[,] w = new bool[7, 10];
            for (int i = 0; i < 7; i++)
            {
                w[i, 0] = listsDays[i].F10T11;
                w[i, 1] = listsDays[i].F11T12;
                w[i, 2] = listsDays[i].F12T13;
                w[i, 3] = listsDays[i].F13T14;
                w[i, 4] = listsDays[i].F14T15;
                w[i, 5] = listsDays[i].F15T16;
                w[i, 6] = listsDays[i].F16T17;
                w[i, 7] = listsDays[i].F17T18;
                w[i, 8] = listsDays[i].F18T19;
                w[i, 9] = listsDays[i].F19T20;
            }
            return w;
        }
    }

    public class work_days
    {
        private readonly string days_hours;
        public string Days_hours => days_hours;
        public work_days(string name)
        {
            days_hours = name;
            F10T11 = false;
            F11T12 = false;
            F12T13 = false;
            F13T14 = false;
            F14T15 = false;
            F15T16 = false;
            F16T17 = false;
            F17T18 = false;
            F18T19 = false;
            F19T20 = false;
        }

        public bool F10T11 { get; set; }
        public bool F11T12 { get; set; }
        public bool F12T13 { get; set; }
        public bool F13T14 { get; set; }
        public bool F14T15 { get; set; }
        public bool F15T16 { get; set; }
        public bool F16T17 { get; set; }
        public bool F17T18 { get; set; }
        public bool F18T19 { get; set; }
        public bool F19T20 { get; set; }
    }
}
