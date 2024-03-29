using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Models
{
	public class Category
	{
        [Key]
        public int Id { get; set; }      
        [Required]
        public string Title { get; set; }
        public Collection<Item> Items { get; set; }
        public Collection<SubCategory> SubCategories { get; set; }
    }
}
