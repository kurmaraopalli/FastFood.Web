using System.ComponentModel.DataAnnotations;

namespace FastFood.Models
{
	public class Category
	{
        [Key]
        public int Id { get; set; }      
        [Required]
        public required string Title { get; set; }
    }
}
