using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atlas.Model_Classes
{
    [Keyless]
    class Salesdisplay
    {

        public string Month { get; set; }
        public float Amount { get; set; }
    }
}
