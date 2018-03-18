using DAL.Interface;
using Model.DB;

namespace DAL.Repositories
{
	public class AnswerRepository : GenericRepository<Answer>, IAnswerRepository
	{
		public AnswerRepository(MainContext context) : base(context)
		{
		}
	}
}
