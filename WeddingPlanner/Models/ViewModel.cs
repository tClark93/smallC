using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner
{

    public class ViewModel
    {
        public User users { get; set; }
        public Event events { get; set; }
        public Guestlist guestlists {get; set;}
    }
}