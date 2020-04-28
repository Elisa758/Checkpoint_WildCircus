using System;
using System.Collections.Generic;
using System.Linq;
using WildCircus;

namespace DataBaseWildCircus
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new CircusContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var performer1 = new Performer()
                {
                    Name = "Moonlight",
                    CreationDate = DateTime.Today,
                    Descritpion = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non risus. Suspendisse lectus tortor, dignissim sit amet, adipiscing nec, ultricies sed, dolor. Cras elementum ultrices diam. Maecenas ligula massa, varius a, semper congue, euismod non, mi. Proin porttitor, orci nec nonummy molestie, enim est eleifend mi, non fermentum diam nisl sit amet erat. Duis semper. Duis arcu massa, scelerisque vitae, consequat in, pretium a, enim. Pellentesque congue. Ut in risus volutpat libero pharetra tempor. Cras vestibulum bibendum augue. Praesent egestas leo in pede. Praesent blandit odio eu enim. Pellentesque sed dui ut augue blandit sodales. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Aliquam nibh. Mauris ac mauris sed pede pellentesque fermentum. Maecenas adipiscing ante non diam sodales hendrerit. ",
                    Image = "/References/MoonLight.jpg"
                };

                var performer2 = new Performer()
                {
                    Name = "SnowFlake",
                    CreationDate = DateTime.Today,
                    Image = "/References/snowflake.jpg",
                    Descritpion = "SnowFlake reunites 8 lovers of circus and ice skating.They join the art of the circus and the disciplines on ice for the first time in our circus." +
                                    "The acrobats take this new iced field game by storm.Figure skating," +
                                    "freestyle skating and extreme skating are mixed with innovative acrobatics" +
                                    "and aerial exploits to create an unexpected show.Thrills guaranteed!",
                };

                var performer3 = new Performer()
                {
                    Name = "WildFlower",
                    CreationDate = DateTime.Today,
                    Descritpion = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non risus. Suspendisse lectus tortor, dignissim sit amet, adipiscing nec, ultricies sed, dolor. Cras elementum ultrices diam. Maecenas ligula massa, varius a, semper congue, euismod non, mi. Proin porttitor, orci nec nonummy molestie, enim est eleifend mi, non fermentum diam nisl sit amet erat. Duis semper. Duis arcu massa, scelerisque vitae, consequat in, pretium a, enim. Pellentesque congue. Ut in risus volutpat libero pharetra tempor. Cras vestibulum bibendum augue. Praesent egestas leo in pede. Praesent blandit odio eu enim. Pellentesque sed dui ut augue blandit sodales. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Aliquam nibh. Mauris ac mauris sed pede pellentesque fermentum. Maecenas adipiscing ante non diam sodales hendrerit. ",
                    Image = "/References/circus.jpg"
                };

                var performer4 = new Performer()
                {
                    Name = "SleepWalking",
                    CreationDate = DateTime.Today,
                    Descritpion = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non risus. Suspendisse lectus tortor, dignissim sit amet, adipiscing nec, ultricies sed, dolor. Cras elementum ultrices diam. Maecenas ligula massa, varius a, semper congue, euismod non, mi. Proin porttitor, orci nec nonummy molestie, enim est eleifend mi, non fermentum diam nisl sit amet erat. Duis semper. Duis arcu massa, scelerisque vitae, consequat in, pretium a, enim. Pellentesque congue. Ut in risus volutpat libero pharetra tempor. Cras vestibulum bibendum augue. Praesent egestas leo in pede. Praesent blandit odio eu enim. Pellentesque sed dui ut augue blandit sodales. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Aliquam nibh. Mauris ac mauris sed pede pellentesque fermentum. Maecenas adipiscing ante non diam sodales hendrerit. ",
                    Image= "/References/sleepwalking.jpg",
                };


                var show1 = new Show()
                {
                    Name = "Crystal",
                    Location = "Paris",
                    Descritpion="Come and see this wonderfull figure skating show",
                    Date = DateTime.Today.AddMonths(3),
                    Price = 30,
                };

                var show2 = new Show()
                {
                    Name = "Stars",
                    Location = "Londres",
                    Descritpion = "Come and see this wonderfull dance show. Many dance groups will show you that the only limit is your imagination",
                    Date = DateTime.Today.AddMonths(6),
                    Price = 40
                };

                List<Show> shows = new List<Show>();
                shows.Add(show1);
                shows.Add(show2);

                List<Performer> performers = new List<Performer>();
                performers.Add(performer1);
                performers.Add(performer2);
                performers.Add(performer3);
                performers.Add(performer4);



                var newPersons = (from i in Enumerable.Range(0, 5)
                                  select new User { Name = "Maximus" + i, Password = "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4" }).ToList();

                List<TicketOrder> ticketOrders1 = GenerateTicketOrders(5, show1);
                List<TicketOrder> ticketOrders2 = GenerateTicketOrders(5, show2);
                List<TicketOrder> ticketOrders = new List<TicketOrder>();
                ticketOrders.AddRange(ticketOrders1);
                ticketOrders.AddRange(ticketOrders2);
                
                List<ShowOrder> showOrders = AssociatedShowAndOrder(shows, ticketOrders);

                PerformerShow performerShow = AssociatedPerformerWithShow(show2, performer1);
                PerformerShow performerShow2 = AssociatedPerformerWithShow(show2, performer3);
                PerformerShow performerShow3 = AssociatedPerformerWithShow(show1, performer2);

                List<Show> newShows = GenerateShows(15);

                context.AddRange(performers);
                context.AddRange(shows);
                context.AddRange(newShows);
                context.AddRange(newPersons);
                context.AddRange(ticketOrders);
                context.AddRange(showOrders);
                context.AddRange(performerShow);
                context.AddRange(performerShow2);
                context.AddRange(performerShow3);
                context.SaveChanges();


            }


        }

        public static List<TicketOrder> GenerateTicketOrders(int numberOfOrder, Show show)
        {
            List<TicketOrder> orders = new List<TicketOrder>();
            Random rdm = new Random();
            for (int i = 1; i <= numberOfOrder; i++)
            {
                var newOrder = new TicketOrder();
                newOrder.OrderDate = DateTime.Today.AddDays(i);
                newOrder.TicketNumber = rdm.Next(1, 10);
                newOrder.Price = newOrder.TicketNumber * show.Price;
                orders.Add(newOrder);
            }
            return orders;
        }

        public static List<ShowOrder> AssociatedShowAndOrder(List<Show> shows, List<TicketOrder> ticketOrders)
        {
            List<ShowOrder> showOrders = new List<ShowOrder>();

            foreach(Show show in shows)
            {
                foreach(TicketOrder ticketOrder in ticketOrders)
                {
                    var showOrder = new ShowOrder { Show = show, ShowId = show.ShowId, TicketOrder = ticketOrder, TicketOrderId = ticketOrder.TicketOrderId };
                    showOrders.Add(showOrder);
                }
            }
            return showOrders;

        }

        public static PerformerShow AssociatedPerformerWithShow(Show show, Performer performer)
        {
            var perfShow = new PerformerShow { Performer = performer, PerformerId = performer.PerformerId, Show = show, ShowId = show.ShowId };
            return perfShow;
        }

        public static List<Show> GenerateShows(int number)
        {
            List<string> Cities = new List<string> { "Paris", "Londres", "New York", "Berlin", "San Fransisco" };
            List<Show> shows = new List<Show>();
            Random rdm = new Random();

            for(int i=1; i<=number; i++)
            {
                int cityIndex = rdm.Next(1, 5);
                var show = new Show()
                {  
                    Name = "Wild Circus - Edition n° " + i,
                    Location = Cities[cityIndex],
                    Descritpion = "Come and see this wonderfull show. Let yourself be carried away in a world where the real and the imaginary are one.",
                    Date = DateTime.Today.AddMonths(rdm.Next(1,18)),
                    Price = rdm.Next(20, 60),
                };
                shows.Add(show);
            }
            return shows;

        }
    }
}
