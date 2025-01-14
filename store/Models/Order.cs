﻿using System;
using System.Collections.Generic;

namespace store.Models
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public string? OrderStatus { get; set; }
        public string? OrderPrice { get; set; }
        public string? OrderDate { get; set; }
        public string? DeliveryAddress { get; set; }
        public int? Buyer { get; set; }

        public virtual Account? BuyerNavigation { get; set; }
    }
}
