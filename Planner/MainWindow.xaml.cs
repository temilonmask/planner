using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Planner.Core;
using Planner.UI;

namespace Planner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static DateTime selectedDate = DateTime.Now;
        string DayOfWeek = selectedDate.DayOfWeek.ToString();
        int Day = selectedDate.Day;
        public DateTime monday;
        public DateTime sunday;
        Plan plan = new Plan();

        /*p
         {
             new Event { 
                 Name = "Test",
                 Description = "Test data",
                 StartDt = new DateTime(2019, 12, 19, 7, 15, 0),
                 EndDt = new DateTime(2019, 12, 19, 14, 45, 0),
                 Tag = "tag"
             },
             new Event {
                 Name = "Test1",
                 Description = "Test data",
                 StartDt = new DateTime(2019, 12, 18, 9, 30, 0),
                 EndDt = new DateTime(2019, 12, 18, 12, 45, 0),
                 Tag = "tag"
             },
             new Event {
                 Name = "Test1",
                 Description = "Test data",
                 StartDt = new DateTime(2019, 12, 24, 9, 30, 0),
                 EndDt = new DateTime(2019, 12, 24, 12, 45, 0),
                 Tag = "tag"
             }
         };*/


        public MainWindow()
        {


            InitializeComponent();
            FillAll();
            FillEvents();
        }

        private void FillAll()
        {
            if (DayOfWeek == "Monday")
            {
                FillAllForDay(0);

            }
            if (DayOfWeek == "Tuesday")
            {
                FillAllForDay(-1);
            }
            if (DayOfWeek == "Wednesday")
            {
                FillAllForDay(-2);
            }
            if (DayOfWeek == "Thursday")
            {
                FillAllForDay(-3);
            }
            if (DayOfWeek == "Friday")
            {
                FillAllForDay(-4);
            }
            if (DayOfWeek == "Saturday")
            {
                FillAllForDay(-5);
            }
            if (DayOfWeek == "Sunday")
            {
                FillAllForDay(-6);
            }
        }

        private void FillAllForDay(int tillMonday) 
        {
            Monday.Text = selectedDate.AddDays(tillMonday).Day.ToString();
            Tuesday.Text = selectedDate.AddDays(tillMonday + 1).Day.ToString();
            Wednesday.Text = selectedDate.AddDays(tillMonday + 2).Day.ToString();
            Thursday.Text = selectedDate.AddDays(tillMonday + 3).Day.ToString();
            Friday.Text = selectedDate.AddDays(tillMonday + 4).Day.ToString();
            Saturday.Text = selectedDate.AddDays(tillMonday + 5).Day.ToString();
            Sunday.Text = selectedDate.AddDays(tillMonday + 6).Day.ToString();
            monthText(tillMonday, tillMonday + 6);
            monday = selectedDate.AddDays(tillMonday);
            sunday = selectedDate.AddDays(tillMonday + 6);
        }

        private void monthText(int tillMonday, int tillSunday)
        {
            if (selectedDate.AddDays(tillMonday).Month == selectedDate.AddDays(tillSunday).Month)
            {
                Month.Text = wordMonth(selectedDate.Month) + " " + selectedDate.Year;
            }
            else if (selectedDate.AddDays(tillMonday).Year == selectedDate.AddDays(tillSunday).Year)
            {
                Month.Text = wordMonth(selectedDate.AddDays(tillMonday).Month) + " - " + wordMonth(selectedDate.AddDays(tillSunday).Month) + " " + selectedDate.Year;
            }
            else
            {
                Month.Text = wordMonth(selectedDate.AddDays(tillMonday).Month) + " " + selectedDate.AddDays(tillMonday).Year.ToString() + " - " + wordMonth(selectedDate.AddDays(tillSunday).Month) + " " + selectedDate.AddDays(tillSunday).Year.ToString();
            }

        }

        private string wordMonth(int month)
        {
            if (month == 1)
            {
                return "January";
            }
            else if (month == 2)
            {
                return "February";
            }
            else if (month == 3)
            {
                return "March";
            }
            else if (month == 4)
            {
                return "April";
            }
            else if (month == 5)
            {
                return "May";
            }
            else if (month == 6)
            {
                return "June";
            }
            else if (month == 7)
            {
                return "July";
            }
            else if (month == 8)
            {
                return "August";
            }
            else if (month == 9)
            {
                return "September";
            }
            else if (month == 10)
            {
                return "October";
            }
            else if (month == 11)
            {
                return "November";
            }
            else
            {
                return "December";
            }
        }

        private void FillEvents()
        {
            List<Event> Events = plan.EventsList();
            foreach (Event currentEvent in Events)
            {
                if ((currentEvent.StartDt > monday) & (currentEvent.EndDt < sunday))
                {
                    Button newButton = new Button();
                    newButton.Content = currentEvent.Name;
                    newButton.VerticalAlignment = VerticalAlignment.Top;
                    TimePad.Children.Add(newButton);
                    newButton.SetValue(Grid.ColumnProperty, (int)currentEvent.StartDt.DayOfWeek - 1);
                    int startTime = currentEvent.StartDt.Hour * 60 + currentEvent.StartDt.Minute;
                    int duration = currentEvent.EndDt.Hour * 60 + currentEvent.EndDt.Minute - startTime;
                    newButton.Height = duration;
                    Thickness margin = newButton.Margin;
                    margin.Top = startTime;
                    newButton.Margin = margin;
                    newButton.Width = 150;
                }
            }
        }

        private void CleanGrid()
        {
            TimePad.Children.Clear();
        }

        private void AddEventButtonClick(object sender, RoutedEventArgs e)
        {
            var AddEvent = new AddEventWindow();
            AddEvent.Show();
            plan.LoadData();

        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            selectedDate = selectedDate.AddDays(7);
            DayOfWeek = selectedDate.DayOfWeek.ToString();
            Day = selectedDate.Day;
            FillAll();
            CleanGrid();
            FillEvents();
        }

        private void PastButton_Click(object sender, RoutedEventArgs e)
        {
            selectedDate = selectedDate.AddDays(-7);
            DayOfWeek = selectedDate.DayOfWeek.ToString();
            Day = selectedDate.Day;
            FillAll();
            CleanGrid();
            FillEvents();
        }

        private void TodayButton_Click(object sender, RoutedEventArgs e)
        {
            selectedDate = DateTime.Now;
            DayOfWeek = selectedDate.DayOfWeek.ToString();
            Day = selectedDate.Day;
            DatePicker.SelectedDate = DateTime.Now;
            FillAll();
            CleanGrid();
            FillEvents();
        }

        private void DateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DatePicker.SelectedDate != null)
            {
                selectedDate = DatePicker.SelectedDate ?? DateTime.Now;
                DayOfWeek = selectedDate.DayOfWeek.ToString();
                Day = selectedDate.Day;
                FillAll();
                CleanGrid();
                FillEvents();
            }
        }

    }
}
