using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Atlas.Model_Classes
{  

    public class MonthlySales
    {
        public string ID{ get; set; }

        public string Month { get; set; }
      
        public float Amount { get; set; }
    }
}
