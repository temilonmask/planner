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
                Month.Text = selectedDate.Month.ToString() + " " + selectedDate.Year;
            }
            else if (selectedDate.AddDays(tillMonday).Year == selectedDate.AddDays(tillSunday).Year)
            {
                Month.Text = selectedDate.AddDays(tillMonday).Month.ToString() + " - " + selectedDate.AddDays(tillSunday).Month.ToString() + " " + selectedDate.Year;
            }
            else
            {
                Month.Text = selectedDate.AddDays(tillMonday).Month.ToString() + " " + selectedDate.AddDays(tillMonday).Year.ToString() + " - " + selectedDate.AddDays(tillSunday).Month.ToString() + " " + selectedDate.AddDays(tillSunday).Year.ToString();
            }

        }

        private void AddEventButtonClick(object sender, RoutedEventArgs e)
        {

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
            FillAll();

        }
    }
}
