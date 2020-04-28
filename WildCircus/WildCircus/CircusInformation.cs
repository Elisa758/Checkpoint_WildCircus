using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WildCircus
{
    public static class CircusInformation
    {
        public static List<Performer> GetPerformers()
        {
            using (var context = new CircusContext())
            {
                var performers = (from p in context.Performers
                                  select p).ToList();
                return performers;
            }
                
        }

        public static List<Show> GetShows()
        {
            using (var context = new CircusContext())
            {
                var shows = (from s in context.Shows
                             select s).ToList();
                return shows;
            }
        }

        public static ShowOrder AssociatedShowWithOrder(Show show, TicketOrder ticketOrder)
        {
            ShowOrder showOrder = new ShowOrder()
            { Show = show, ShowId = show.ShowId, TicketOrder = ticketOrder, TicketOrderId = ticketOrder.TicketOrderId };
            return showOrder;
        }

        public static List<PerformerShow> AssociatedShowWithPerformer(Show show, List<Performer> performers)
        {
            List<PerformerShow> performerShows = new List<PerformerShow>();
            foreach(var performer in performers)
            {
                PerformerShow performerShow = new PerformerShow()
                { Performer = performer, PerformerId = performer.PerformerId, Show = show, ShowId = show.ShowId };

                performerShows.Add(performerShow);
            }
            return performerShows;
        }

        public static List<TicketOrder> GetAllOrders()
        {
            using (var context = new CircusContext())
            {
                var orders = (from t in context.TicketOrders
                          select t).ToList();

                return orders;
            }

        }
    }
}
