using Planner.Core;
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

namespace Planner.UI
{
    /// <summary>
    /// Логика взаимодействия для EventInfo.xaml
    /// </summary>
    public partial class EventInfo : Window
    {

        public EventInfo(Event currentEvent)
        {
            InitializeComponent();
            Name.Text = currentEvent.Name;
            BeginDt.Text = "From " + currentEvent.StartDt.ToString();
            EndDt.Text = "To " + currentEvent.EndDt.ToString();
            Description.Text = "Description: " + currentEvent.Description;
            Tag.Text = "Tag: " + currentEvent.Tag;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
