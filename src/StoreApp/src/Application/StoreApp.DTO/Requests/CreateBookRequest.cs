﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DTO.Requests
{
    public class CreateBookRequest
    {
        [Required]
        public string Title { get; set; }
        public decimal Price { get; set; }
    }
}
