using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.DAL.Enitities
{
    public class SubElement
    {
        [Key]
        public int Id { get; set; }
        public int Element { get; set; }
        public string Type { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int WindowId { get; set; }
        public Window Window { get; set; }
    }
}
