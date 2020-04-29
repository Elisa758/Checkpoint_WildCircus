using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace WildCircus
{

    public partial class ExportWindow : Window
    {
        public ExportWindow()
        {
            InitializeComponent();
        }

        private void Export_Order_Btn_Click(object sender, RoutedEventArgs e)
        {
            
            var client = new WebClient();
            client.DownloadString(@"http://localhost:1234/export/orders");
            MessageBox.Show("Export orders successfull");


        }

        private void Export_Shows_Btn_Click(object sender, RoutedEventArgs e)
        {
            var client = new WebClient();
            client.DownloadString(@"http://localhost:1234/export/shows");
            MessageBox.Show("Export shows successfull");
        }

        private void Export_Performers_Btn_Click(object sender, RoutedEventArgs e)
        {
            var client = new WebClient();
            client.DownloadString(@"http://localhost:1234/export/performers");
            MessageBox.Show("Export performers successfull");
        }

        private void Cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
