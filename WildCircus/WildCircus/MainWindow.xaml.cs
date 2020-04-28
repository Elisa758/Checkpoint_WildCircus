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

namespace WildCircus
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PerformerMenu_Click(object sender, RoutedEventArgs e)
        {
            PerformersWindow performersWindow = new PerformersWindow();
            performersWindow.Show();
            this.Close();

        }

        private void HomeMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Activate();
        }

        private void ShowMenu_Click(object sender, RoutedEventArgs e)
        {
            ShowsWindow showsWindow = new ShowsWindow();
            showsWindow.Show();
            this.Close();
        }

        private void ExportMenu_Click(object sender, RoutedEventArgs e)
        {
            ExportWindow exportWindow = new ExportWindow();
            exportWindow.Show();
        }

        private void ContactMenu_Click(object sender, RoutedEventArgs e)
        {
            ContactWindow contactWindow = new ContactWindow();
            contactWindow.Show();
        }
    }
}
