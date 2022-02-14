using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Atlas.Model_Classes
{   
    [Keyless]
    public class MonthlySales
    {
        public string Month { get; set; }
        public float Amount { get; set; }
    }
}
