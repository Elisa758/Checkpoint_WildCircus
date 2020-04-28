using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WildCircus
{
    public partial class ShowsWindow : Window
    {
        public List<Show> Shows { get; set; }
        public ShowsWindow()
        {
            InitializeComponent();
            Shows = CircusInformation.GetShows();
            Shows_ListView.ItemsSource = Shows;
        }

        private void PerformerMenu_Click(object sender, RoutedEventArgs e)
        {
            PerformersWindow performersWindow = new PerformersWindow();
            performersWindow.Show();
            this.Close();

        }

        private void HomeMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void ShowMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Activate();
        }

        private void ExportMenu_Click(object sender, RoutedEventArgs e)
        {
            ExportWindow exportWindow = new ExportWindow();
            exportWindow.Show();
        }

        private void Order_Btn_Click(object sender, RoutedEventArgs e)
        {
            OrderTicketsForAShowWindow orderTicketsWindow = new OrderTicketsForAShowWindow(this);
            orderTicketsWindow.Show();
            orderTicketsWindow.Closed += (s, eventarg) =>
            {

                this.Activate();
            };
        }

        private void ContactMenu_Click(object sender, RoutedEventArgs e)
        {
            ContactWindow contactWindow = new ContactWindow();
            contactWindow.Show();
        }

        private void Add_Shows_Btn_Click(object sender, RoutedEventArgs e)
        {
            AddShowWindow addShowWindow = new AddShowWindow();
            addShowWindow.Show();
            addShowWindow.Closed += (s, eventarg) =>
            {
                Shows = CircusInformation.GetShows();
                Shows_ListView.ItemsSource = Shows;
            };
        }
    }
}
