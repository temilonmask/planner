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
            var backtomain = new MainWindow();
            backtomain.Show();
        }

        private void AddEventButtonClick(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            DateTime? StartDt = StartDayPicker.SelectedDate;
            DateTime? EndDt = EndDayPicker.SelectedDate;
            DateTime? StartT = StartTimePicker.SelectedTime;
            DateTime? EndT = EndTimePicker.SelectedTime;
            string description = Description.Text;
        }
    }
}
