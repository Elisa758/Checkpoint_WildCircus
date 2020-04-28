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
    public partial class OrderTicketsForAShowWindow : Window
    {
        public Show SelectedShow { get; set; }

        public OrderTicketsForAShowWindow(ShowsWindow owner)
        {
            InitializeComponent();
            this.Owner = owner;
            DataContext = owner.Shows_ListView.SelectedItem;
            SelectedShow = (Show)owner.Shows_ListView.SelectedItem;
            this.Title = "Tickets for " + SelectedShow.Name +" :";

            ShowName_Label.Content = SelectedShow.Name;
            ShowDate_Label.Content = SelectedShow.Date.ToString("MM/dd/yyyy");
            ShowLocation_Label.Content = SelectedShow.Location;
            Price_TextBlock.Text = SelectedShow.Price.ToString();
            Description_TextBlock.Text = SelectedShow.Descritpion;

            List<int> quantity = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Quantity_ComboBox.ItemsSource = quantity;
            Quantity_ComboBox.SelectionChanged += new SelectionChangedEventHandler(Quantity_ComboBox_SelectionChanged);
        }

        private void Quantity_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int quantity = Convert.ToInt32(Quantity_ComboBox.SelectedItem);
            decimal newPrice = SelectedShow.Price * quantity;
            Price_TextBlock.Text = newPrice.ToString();
        }

        private void Validate_btn_Click(object sender, RoutedEventArgs e)
        {
            if(Quantity_ComboBox.SelectedItem != null)
            {
                var context = new CircusContext();

                var ticketOrder = new TicketOrder()
                {
                    Price = Convert.ToDecimal(Price_TextBlock.Text),
                    TicketNumber = Convert.ToInt32(Quantity_ComboBox.SelectedItem),
                    OrderDate = DateTime.Today,
                };

                ShowOrder showOrder = CircusInformation.AssociatedShowWithOrder(SelectedShow, ticketOrder);
                ticketOrder.ManyShowOrder.Add(showOrder);

                context.Update(ticketOrder);
                context.SaveChanges();

                MessageBox.Show("Ticket(s) ordered for the show : " + SelectedShow.Name);
                this.Close();
            }
            else
            {
                MessageBox.Show("Select a quantity");
            }
        }

        private void Cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
