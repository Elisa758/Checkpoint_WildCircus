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
    public partial class ContactWindow : Window
    {
        public ContactWindow()
        {
            InitializeComponent();
        }

        private void Send_Btn_Click(object sender, RoutedEventArgs e)
        {
            string mail = Mail_TextBox.Text;
            string message = Message_TextBox.Text;
            if (mail != String.Empty && message != String.Empty)
            {
                
                var context = new CircusContext();
                Contact newContact = CreateContact(mail, message);
                context.Add(newContact);
                context.SaveChanges();
                MessageBox.Show("Message send");
                this.Close();
            }
            else
            {
                MessageBox.Show("You have to complete every field");
            }

        }

        private void Cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public Contact CreateContact(string mail, string message)
        {
            Contact newContact = new Contact()
            {
                Email = mail,
                Message = message,
            };
            return newContact;
        }

    }

}
