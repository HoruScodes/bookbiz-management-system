﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBiz_Management_System.BLL
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }

        public string Category { get; set; }
        public int UnitPrice { get;  set; }
        public int PublicationYear { get; set; }

    }
}
