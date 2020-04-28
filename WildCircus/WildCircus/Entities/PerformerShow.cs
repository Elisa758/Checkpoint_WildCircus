using System;
using System.Collections.Generic;
using System.Text;

namespace WildCircus
{
    public class PerformerShow
    {
        public Guid PerformerId { get; set; }
        public Performer Performer { get; set; }
        public Guid ShowId { get; set; }
        public Show Show { get; set; }
    }
}
