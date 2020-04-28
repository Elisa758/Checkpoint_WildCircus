using System;
using System.Collections.Generic;
using System.Text;
using Nancy;
using WildCircus;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

namespace WildCircus_WebService
{
    public class Module : NancyModule
    {
        public Module()
        {
            //Get(@"/export/orders", parameters => ExportAllOrders());
            Put(@"/export/orders", parameters => ExportAllOrders());

            Get(@"/export/shows", parameters => ExportAllShows());
            Get(@"/export/performers", parameters => ExportAllPerformers());
        }


        public dynamic ExportAllOrders()
        {
            CreateFile(@"..\netcoreapp3.1\orders.txt");
            List<TicketOrder> orders = CircusInformation.GetAllOrders();
            using (StreamWriter file = File.CreateText(@"..\netcoreapp3.1\orders.txt"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, orders);

                return "export successfull";
            }
        }


        public dynamic ExportAllPerformers()
        {
            CreateFile(@"..\netcoreapp3.1\perfomers.txt");
            List<Performer> performers = CircusInformation.GetPerformers();
            using (StreamWriter file = File.CreateText(@"..\netcoreapp3.1\perfomers.txt"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, performers);

                return "export successfull";
            }
        }

        public dynamic ExportAllShows()
        {
            CreateFile(@"..\netcoreapp3.1\shows.txt");
            List<Show> shows = CircusInformation.GetShows();
            using (StreamWriter file = File.CreateText(@"..\netcoreapp3.1\shows.txt"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, shows);

                return "export successfull";
            }
        }

        public void CreateFile(string filepath)
        {
            TextWriter textWrite = new StreamWriter(filepath);
            textWrite.Write("test");
            textWrite.Flush();
            textWrite.Close();
            textWrite = null;
        }

    }
}
