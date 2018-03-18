using DAL.Interface;
using Model.DB;

namespace DAL.Repositories
{
	public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
	{
		public SubjectRepository(MainContext context) : base(context)
		{
		}
	}
}
