using FastFood.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FastFood.Repository
{
	public class DbInitializer : IDbInitializer
	{
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly UserManager<IdentityUser> _identityUser;
		private readonly ApplicationDBContext _context;
		public DbInitializer(RoleManager<IdentityRole> roleManager,
			UserManager<IdentityUser> identityUser,
			ApplicationDBContext context)
		{
			_roleManager = roleManager;
			_identityUser = identityUser;
			_context = context;
		}
		public void Initialize()
		{
			try
			{
				if (_context.Database.GetPendingMigrations().Count() > 0) { 
				_context.Database.Migrate();
				}
			}
			catch (Exception)
			{
				throw;
			}

			if (_context.Roles.Any(x => x.Name == "Admin")) return;
			_roleManager.CreateAsync(new IdentityRole("Manager")).GetAwaiter().GetResult();
			_roleManager.CreateAsync(new IdentityRole("Admin")).GetAwaiter().GetResult();
			_roleManager.CreateAsync(new IdentityRole("Customer")).GetAwaiter().GetResult();

			var applicationUser = new ApplicationUser() {
			UserName = "admin@gmail.com",
			Email ="admin@gmail.com",
			Name ="Admin",
			City ="Blore",
			Address="Blore",
			PostalCode="12345"
			};

			_identityUser.CreateAsync(applicationUser, "Admin@123").GetAwaiter().GetResult();
			_identityUser.AddToRoleAsync(applicationUser, "Admin");
		}
	}
}
