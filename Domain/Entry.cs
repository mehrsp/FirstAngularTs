using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Entry
    {
        [Key]
        public int EntryId { get; set; }
        public string Desc { get; set; }
        public bool IsExpense { get; set; }
        public double value { get; set; }
    }
}
