using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WildCircus
{
    public partial class OrderTicketsWindow : Window
    {
        public OrderTicketsWindow()
        {
            InitializeComponent();
            List<Show> shows = CircusInformation.GetShows();
            Shows_ListView.ItemsSource = shows;


            List<int> quantity = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            

            //Quantity_ComboBox.ItemsSource = quantity;
            //Quantity_ComboBox.SelectionChanged += new SelectionChangedEventHandler(Quantity_ComboBox_SelectionChanged);
        }

        private void HomeMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void PerformerMenu_Click(object sender, RoutedEventArgs e)
        {
            PerformersWindow performersWindow = new PerformersWindow();
            performersWindow.Show();
            this.Close();

        }

        private void ShowMenu_Click(object sender, RoutedEventArgs e)
        {
            ShowsWindow showsWindow = new ShowsWindow();
            showsWindow.Show();
            this.Close();
        }

        private void OrderMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Activate();
        }

        private void ExportMenu_Click(object sender, RoutedEventArgs e)
        {
            ExportWindow exportWindow = new ExportWindow();
            exportWindow.Show();
            this.Close();
        }

        private void Quantity_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void ContactMenu_Click(object sender, RoutedEventArgs e)
        {
            ContactWindow contactWindow = new ContactWindow();
            contactWindow.Show();
        }

    }
}
