using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace WildCircus
{
    public class Performer : INotifyPropertyChanged
    {
        public Guid PerformerId { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public string Descritpion { get; set; }
        public string Image { get; set; }
        public ICollection<PerformerShow> ManyPerformerShow { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public override String ToString()
        {
            return Name;
        }
    }
}