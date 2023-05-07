﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Shared.Models
{
    public class WindowDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int QuantityOfWindows { get; set; }
        public int TotalSubElements { get; set; }
        [Required]
        public int OrderId { get; set; }
    }
}