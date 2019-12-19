using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Planner.Core;

namespace Planner.UI
{
    /// <summary>
    /// Логика взаимодействия для AddEventWindow.xaml
    /// </summary>
    public partial class AddEventWindow : Window
    {
        public AddEventWindow()
        {
            InitializeComponent();
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddEventButtonClick(object sender, RoutedEventArgs e)
        {
            Plan planner = new Plan();
            string name = NameTextBox.Text ?? "No name";
            string description = Description.Text;

            DateTime StartDt = StartDayPicker.SelectedDate ?? DateTime.Today;
            DateTime StartT = StartTimePicker.SelectedTime ?? DateTime.Now;
            DateTime Start = new DateTime(StartDt.Year, StartDt.Month, StartDt.Day, StartT.Hour, StartT.Minute, StartT.Second);

            //TimeSpan diffStart = StartT.TimeOfDay - StartDt.TimeOfDay;
            //StartDt.AddDays(diffStart.TotalHours);
            //StartDt.AddHours(diffStart.TotalHours).AddMinutes(diffStart.Minutes);

            DateTime EndDt = EndDayPicker.SelectedDate ?? DateTime.Today;
            DateTime EndT = EndTimePicker.SelectedTime ?? DateTime.Now;
            DateTime End = new DateTime(EndDt.Year, EndDt.Month, EndDt.Day, EndT.Hour, EndT.Minute, EndT.Second);

            //TimeSpan diffEnd = EndT.TimeOfDay - EndDt.TimeOfDay;
            //StartDt.AddDays(diffStart.TotalHours);
            //EndDt.AddHours(diffEnd.TotalHours).AddMinutes(diffEnd.Minutes);

            bool IsTimeAndDateOk = Start < End;

            if (IsTimeAndDateOk && planner.CheckDates(StartDt, EndDt))
            {
                Event newevent = new Event
                {
                    Name = name,
                    StartDt = Start,
                    EndDt = End,
                    Description = description,
                    Tag = null
                };
                planner.AddEvent(newevent);
                Close();
            }
            else
                MessageBox.Show("Chosen time is incorrect or busy");
            
        }
    }
}
