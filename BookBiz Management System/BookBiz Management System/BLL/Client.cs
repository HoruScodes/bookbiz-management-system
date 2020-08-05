using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBiz_Management_System.BLL
{
    public class Client
    {
        public string ClientName { get; set; }
        public string ClientStreet { get; set; }
        public string ClientCity { get; set; }
        public string ClientPhoneNumber { get; set; }
        public string ClientPostalcode { get; set; }
        public string ClientFaxNumber { get; set; }
        public int ClientCreditLimit { get; set; }
    }
}
