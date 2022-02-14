using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Atlas.Model_Classes
{
    public class Accountlog
    {
        [Key]
        public int LogAccID { get; set; }
        public string LogDateandTime { get; set; }
        public string LogAccRemarks { get; set; }
    }
}
