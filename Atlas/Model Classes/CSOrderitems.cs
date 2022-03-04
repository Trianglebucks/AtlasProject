
using System.ComponentModel.DataAnnotations;

namespace Atlas.Model_Classes
{
    public class CSOrderitems
    {
        [Key]
        public string TrackingNumber { get; set; }

        [Key]
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public string Brand { get; set; }

        public int Quantity { get; set; }

        public float UnitPrice { get; set; }
        public float TotPrice { get; set; }

        public string OrderDate { get; set; }

    }
}
