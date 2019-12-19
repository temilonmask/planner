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
        
        

        public MainWindow()
        {

            Plan plan = new Plan();
            InitializeComponent();
            FillAll();
        }

        private void FillAll()
        {
            if (DayOfWeek == "Monday")
            {
                Monday.Text = Day.ToString();
                Tuesday.Text = selectedDate.AddDays(1).Day.ToString();
                Wednesday.Text = selectedDate.AddDays(2).Day.ToString();
                Thursday.Text = selectedDate.AddDays(3).Day.ToString();
                Friday.Text = selectedDate.AddDays(4).Day.ToString();
                Saturday.Text = selectedDate.AddDays(5).Day.ToString();
                Sunday.Text = selectedDate.AddDays(6).Day.ToString();
                monthText(0, 6);

            }
            if (DayOfWeek == "Tuesday")
            {
                Tuesday.Text = Day.ToString();
                Monday.Text = selectedDate.AddDays(-1).Day.ToString();
                Wednesday.Text = selectedDate.AddDays(1).Day.ToString();
                Thursday.Text = selectedDate.AddDays(2).Day.ToString();
                Friday.Text = selectedDate.AddDays(3).Day.ToString();
                Saturday.Text = selectedDate.AddDays(4).Day.ToString();
                Sunday.Text = selectedDate.AddDays(5).Day.ToString();
                monthText(-1, 5);
            }
            if (DayOfWeek == "Wednesday")
            {
                Wednesday.Text = Day.ToString();
                Tuesday.Text = selectedDate.AddDays(-1).Day.ToString();
                Monday.Text = selectedDate.AddDays(-2).Day.ToString();
                Thursday.Text = selectedDate.AddDays(1).Day.ToString();
                Friday.Text = selectedDate.AddDays(2).Day.ToString();
                Saturday.Text = selectedDate.AddDays(3).Day.ToString();
                Sunday.Text = selectedDate.AddDays(4).Day.ToString();
                monthText(-2, 4);
            }
            if (DayOfWeek == "Thursday")
            {
                Thursday.Text = Day.ToString();
                Tuesday.Text = selectedDate.AddDays(-2).Day.ToString();
                Wednesday.Text = selectedDate.AddDays(-1).Day.ToString();
                Monday.Text = selectedDate.AddDays(-3).Day.ToString();
                Friday.Text = selectedDate.AddDays(1).Day.ToString();
                Saturday.Text = selectedDate.AddDays(2).Day.ToString();
                Sunday.Text = selectedDate.AddDays(3).Day.ToString();
                monthText(-3, 3);
            }
            if (DayOfWeek == "Friday")
            {
                Friday.Text = Day.ToString();
                Tuesday.Text = selectedDate.AddDays(-3).Day.ToString();
                Wednesday.Text = selectedDate.AddDays(-2).Day.ToString();
                Thursday.Text = selectedDate.AddDays(-1).Day.ToString();
                Monday.Text = selectedDate.AddDays(-4).Day.ToString();
                Saturday.Text = selectedDate.AddDays(1).Day.ToString();
                Sunday.Text = selectedDate.AddDays(2).Day.ToString();
                monthText(-4, 2);
            }
            if (DayOfWeek == "Saturday")
            {
                Saturday.Text = Day.ToString();
                Tuesday.Text = selectedDate.AddDays(-4).Day.ToString();
                Wednesday.Text = selectedDate.AddDays(-3).Day.ToString();
                Thursday.Text = selectedDate.AddDays(-2).Day.ToString();
                Friday.Text = selectedDate.AddDays(-1).Day.ToString();
                Monday.Text = selectedDate.AddDays(-5).Day.ToString();
                Sunday.Text = selectedDate.AddDays(1).Day.ToString();
                monthText(-5, 1);
            }
            if (DayOfWeek == "Sunday")
            {
                Sunday.Text = Day.ToString();
                Tuesday.Text = selectedDate.AddDays(-5).Day.ToString();
                Wednesday.Text = selectedDate.AddDays(-4).Day.ToString();
                Thursday.Text = selectedDate.AddDays(-3).Day.ToString();
                Friday.Text = selectedDate.AddDays(-2).Day.ToString();
                Saturday.Text = selectedDate.AddDays(-1).Day.ToString();
                Monday.Text = selectedDate.AddDays(-6).Day.ToString();
                monthText(-6, 0);
            }

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

        private void AddEventButtonClick(object sender, RoutedEventArgs e)
        {
            var AddEvent = new AddEventWindow();
            AddEvent.Show();
            Button test = new Button();
            test.Content = "Test";
            TimePad.Children.Add(test);
            test.SetValue(Grid.ColumnProperty, 2);
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            selectedDate = selectedDate.AddDays(7);
            DayOfWeek = selectedDate.DayOfWeek.ToString();
            Day = selectedDate.Day;
            FillAll();
        }

        private void PastButton_Click(object sender, RoutedEventArgs e)
        {
            selectedDate = selectedDate.AddDays(-7);
            DayOfWeek = selectedDate.DayOfWeek.ToString();
            Day = selectedDate.Day;
            FillAll();
        }

        private void TodayButton_Click(object sender, RoutedEventArgs e)
        {
            selectedDate = DateTime.Now;
            DayOfWeek = selectedDate.DayOfWeek.ToString();
            Day = selectedDate.Day;
            DatePicker.SelectedDate = DateTime.Now;
            FillAll();
        }

        private void DateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DatePicker.SelectedDate != null)
            {
                selectedDate = DatePicker.SelectedDate ?? DateTime.Now;
                DayOfWeek = selectedDate.DayOfWeek.ToString();
                Day = selectedDate.Day;
                FillAll();
            }
        }

    }
}
