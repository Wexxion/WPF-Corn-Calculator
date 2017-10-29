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

namespace Маме
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void average_Click(object sender, RoutedEventArgs e)
        {
            var averageWindow = new AverageWindow(this);
            averageWindow.Show();
        }

        private void pertene_Click(object sender, RoutedEventArgs e)
        {
            var perteneWindow = new PerteneWindow(this);
            perteneWindow.Show();
         
        }
        private void History_OnClick(object sender, RoutedEventArgs e)
        {
            var perteneWindow = new AverageHistory(this);
            perteneWindow.Show();
        }
    }
}
