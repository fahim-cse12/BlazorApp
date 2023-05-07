using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.DAL.Enitities
{
    public class Window
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int QuantityOfWindows { get; set; }
        public int TotalSubElements { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public ICollection<SubElement> SubElements { get; set; }
    }
}
