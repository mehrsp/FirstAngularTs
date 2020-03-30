using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
   public class EntryViewModel
    {
        //public IEnumerable<Entry> Entries { get; set; }
        public int entryid { get; set; }
        public string desc { get; set; }
        public bool isexpense { get; set; }
        public double value { get; set; }

    }
}
