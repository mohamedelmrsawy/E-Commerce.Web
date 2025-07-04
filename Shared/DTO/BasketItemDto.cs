﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class BasketItemDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = default!;
        public string ProductUrl { get; set; } = default!;
        [Range(1, 100)]
        public decimal Price { get; set; }
        [Range(1, 100)]
        public int Quantity { get; set; }
    }
}
