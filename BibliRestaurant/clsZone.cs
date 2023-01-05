using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliRestaurantBDD
{
   public class Zone : INotifyPropertyChanged
    {
        public int ID { get; internal set; }
        public string Description { get; set; }
        public bool Fumeur  { get; set; }









        public event PropertyChangedEventHandler PropertyChanged;
    }
}
