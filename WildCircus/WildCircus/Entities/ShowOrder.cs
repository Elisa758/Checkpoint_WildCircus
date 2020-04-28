using System;
using System.Collections.Generic;
using System.Text;

namespace WildCircus
{
    public class ShowOrder
    {
        public Guid ShowId { get; set; }
        public Show Show { get; set; }
        public Guid TicketOrderId { get; set; }
        public TicketOrder TicketOrder { get; set; }
    }
}
