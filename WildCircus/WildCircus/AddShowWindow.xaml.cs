using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class AddShowWindow : Window
    {
        public AddShowWindow()
        {
            InitializeComponent();

            List<Performer> performers = CircusInformation.GetPerformers();
            Performers_ListBox.ItemsSource = performers;
        }

        private void AddShow_Button_Click(object sender, RoutedEventArgs e)
        {
            if(IsAllBoxFilled()==true)
            { 
                var context = new CircusContext();

                Show newShow = new Show();
                newShow.Name = Name_TextBox.Text;
                newShow.Date = Date_DatePicker.SelectedDate.Value;
                newShow.Location = Location_TextBox.Text;
                newShow.Price = Convert.ToInt32(Price_TextBox.Text);

                List<Performer> selectedPerformers = new List<Performer>();

                foreach(var item in Performers_ListBox.SelectedItems)
                {
                    Performer performer = (Performer)item; 
                    selectedPerformers.Add(performer);
                }

                List<PerformerShow> performerShows = CircusInformation.AssociatedShowWithPerformer(newShow, selectedPerformers);
                newShow.ManyPerformerShow.AddRange(performerShows);

                context.Update(newShow);
                context.SaveChanges();

                MessageBox.Show("New Show added");
            }
            else
            {
                MessageBox.Show("You must filled every fields");

            }

        }

        private bool IsAllBoxFilled()
        {
            if(Name_TextBox.Text != String.Empty && Location_TextBox.Text != String.Empty && Price_TextBox.Text!= String.Empty && Performers_ListBox.SelectedItem!=null 
                && Date_DatePicker.SelectedDate.HasValue)
            {
                return true;
            }
            else { return false; }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
