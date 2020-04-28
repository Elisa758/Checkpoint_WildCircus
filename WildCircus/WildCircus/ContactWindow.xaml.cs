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

        private void Cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Send_Btn_Click(object sender, RoutedEventArgs e)
        {
            if(Mail_TextBox.Text !=null && Message_TextBox.Text !=null )
            {
                string mail = Mail_TextBox.Text;
                string message = Message_TextBox.Text;
                var context = new CircusContext();
                Contact newContact = CreateContact(mail, message);
                context.Add(newContact);
                context.SaveChanges();
                MessageBox.Show("Message send");
                this.Close();
            }
            else
            {
                MessageBox.Show("You have to fill every field");
            }

        }

        private void Mail_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool result = ValidateExtension.IsValidEmailAddress(Mail_TextBox.Text);
            
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

    public static class ValidateExtension
    {

        public static bool IsValidEmailAddress(this string s)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(s);
        }
    }
}
