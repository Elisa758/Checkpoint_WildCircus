using System;
using System.Collections.Generic;
using System.Text;

namespace WildCircus
{
    public class Show
    {
        public Guid ShowId { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Descritpion { get; set; }
        public Decimal Price { get; set; }
        public List<PerformerShow> ManyPerformerShow { get; set; } = new List<PerformerShow>();
        public ICollection<ShowOrder> ManyShowOrder { get; set; }


    }
}