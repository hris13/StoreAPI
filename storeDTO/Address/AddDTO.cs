﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace storeDTO.Address
{
    public class AddDTO
    {
        
        public int? AccountId { get; set; }
        public string? StreetName { get; set; }
        public string? StreetNumber { get; set; }
        public string? ZipCode { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
    }
}
