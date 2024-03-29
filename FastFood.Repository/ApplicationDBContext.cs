using FastFood.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FastFood.Repository
{
	public class ApplicationDBContext : IdentityDbContext
	{
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
		{

		}
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
		public DbSet<Cart> Carts { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Coupon> Coupons { get; set; }	
	   public DbSet<Item> items { get; set; }
		public DbSet<OrderDetails> OrderDetails { get; set; }
		public DbSet<OrderHeader> OrderHeaders { get; set; }
		public DbSet<SubCategory> SubCategories { get; set; }
	}	
}