using DAL.Interface;
using Model.DB;

namespace DAL.Repositories
{
	public class UserRepository : GenericRepository<ApplicationUser>, IUserRepository
	{
		public UserRepository(MainContext context) : base(context)
		{
		}
	}
}
