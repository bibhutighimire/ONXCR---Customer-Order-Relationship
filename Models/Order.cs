using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace Customer_Order.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DateOfOrder { get; set; }
        public float? AmountOfOrder { get; set; }
        public Customer? Customer { get; set; }
        public Guid? CustomerId { get; set; }
    }
}
