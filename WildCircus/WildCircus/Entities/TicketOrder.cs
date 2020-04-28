using System;
using System.Collections.Generic;
using System.Text;

namespace WildCircus
{
    public class TicketOrder
    {
        public Guid TicketOrderId { get; set; }
        public Decimal Price { get; set; }
        public int TicketNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<ShowOrder> ManyShowOrder { get; set; } = new List<ShowOrder>();

    }
}