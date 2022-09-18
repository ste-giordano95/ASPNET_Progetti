using System.ComponentModel.DataAnnotations;

namespace ASPNET_MVC_Core.Models
{
    public class Join
    {
        public int OrderId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? OrderDate { get; set; }
        public string CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

    }
}
