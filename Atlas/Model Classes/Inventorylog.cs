using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Atlas.Model_Classes
{
    public class Inventorylog
    {      
        [Key]
        public int LogInvID { get; set; }
        public int ProdID { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public float Price { get; set; }
        public string Measurement { get; set; }
        public string Color { get; set; }
        public string Category { get; set; }
        public int Stocks { get; set; }
        public int Defectives { get; set; }
        public string LogActivity { get; set; }
    }
}
