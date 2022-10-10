using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace storeDTO.Address
{
    public class OrderDTO
    {
        public string? OrderStatus { get; set; }
        public string? OrderPrice { get; set; }
        public string? OrderDate { get; set; }
        public string? DeliveryAddress { get; set; }
        public int? Buyer { get; set; }
    }
}
