using System.ComponentModel.DataAnnotations;

namespace Blazor.DAL.Enitities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public ICollection<Window> Windows { get; set; }
    }
}
