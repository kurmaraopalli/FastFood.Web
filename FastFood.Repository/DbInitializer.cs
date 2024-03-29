using Microsoft.AspNetCore.Identity;

namespace FastFood.Repository
{
	public class DbInitializer : IDbInitializer
	{
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly UserManager<IdentityUser> _identityUser;
		private readonly ApplicationDBContext _context;

		public void Initialize()
		{
			throw new NotImplementedException();
		}
	}
}
