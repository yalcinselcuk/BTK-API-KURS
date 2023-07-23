using System.ComponentModel.DataAnnotations;

namespace StoreApp.Entities
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public decimal Price { get; set; }
    }
}
