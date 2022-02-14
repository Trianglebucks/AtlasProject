using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Atlas.Model_Classes
{   
    public class Deliverylog
    {
        [Key]
        public int LogDelID { get; set; }

        public int TrackingNumber { get; set; }

        public int CustomerID { get; set; }

        public string Address { get; set; }

        public int Quantity { get; set; }

        public float Amount { get; set; }

        public string OrderDate { get; set; }
    }
}
