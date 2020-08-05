using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookBiz_Management_System.BLL
{
    public class Orders
    {
        public string BookName { get; set; }
        public string ClientName { get; set; }
        public string Quantity { get; set; }
        public string Date { get; set; }
        public string TakenVia { get; set; }
    }
}
