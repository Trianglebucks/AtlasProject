using Atlas.Model_Classes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atlas
{
    public class Accounts
    {
        [Key]
        public int AccID { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}