using System.Windows;

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

        private void Task1_History_OnClick(object sender, RoutedEventArgs e)
        {
            var taskWindow = new Task1History(this);
            taskWindow.Show();
        }

        private void Task2_History_OnClick(object sender, RoutedEventArgs e)
        {
            var taskWindow = new Task2History(this);
            taskWindow.Show();
        }
    }
}