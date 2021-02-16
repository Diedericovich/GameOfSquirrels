using System;
using System.Windows;

namespace _GameOfSquirrels
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void NewGame(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(Convert.ToInt32(slPlayers.Value));
            mainWindow.Show();
        }
    }
}