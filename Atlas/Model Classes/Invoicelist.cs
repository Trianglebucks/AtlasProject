using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Atlas.Model_Classes
{
    [Keyless]
    public class Invoicelist
    {
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public float UnitPrice { get; set; }
        public float TotPrice { get; set; }
    }
}
