using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Shared.Models
{
    public class SubElementDto
    {
        public int Id { get; set; }
        [Required]
        public int Element { get; set; }
        [Required]
        public string Type { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        [Required]
        public int WindowId { get; set; }
    }
}
