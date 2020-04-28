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
using System.Windows.Shapes;

namespace WildCircus
{

    public partial class PerformersWindow : Window
    {
        public Performer SelectedPerformer { get; set; }

        public PerformersWindow()
        {
            InitializeComponent();
            List<Performer> performers = CircusInformation.GetPerformers();
            Performers_ComboBox.ItemsSource = performers;

            Performers_ComboBox.SelectionChanged += new SelectionChangedEventHandler(Performers_ComboBox_SelectionChanged);

            int nbOfPerformers = performers.Count;
            Random rdm = new Random();
            int indexAlea = rdm.Next(0, nbOfPerformers);

            PerformerName_TextBlock.Text = performers[indexAlea].Name;
            PerformerDescription_TextBlock.Text = performers[indexAlea].Descritpion;

            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(performers[indexAlea].Image, UriKind.Relative);
            bi3.EndInit();

            Image_Performers.Source = bi3;
        }

        private void Performers_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedPerformer = (Performer)Performers_ComboBox.SelectedItem;

            PerformerName_TextBlock.Text = SelectedPerformer.Name;
            PerformerDescription_TextBlock.Text = SelectedPerformer.Descritpion;

            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(SelectedPerformer.Image, UriKind.Relative);
            bi3.EndInit();

            Image_Performers.Source = bi3;
        }

        private void PerformerMenu_Click(object sender, RoutedEventArgs e)
        {

            this.Activate();

        }

        private void HomeMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
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
