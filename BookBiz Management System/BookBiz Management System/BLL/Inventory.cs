using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBiz_Management_System.BLL
{
    public class Inventory
    {
        public int PublisherId { get;  set; }
        public string PublisherName { get; set; }
        public int ISBN { get; set; }
        public int QOH { get; set; } 
    }
}
