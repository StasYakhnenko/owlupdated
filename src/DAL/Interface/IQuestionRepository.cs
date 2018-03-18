using Model.DB;

namespace DAL.Interface
{
	public interface IQuestionRepository : IGenericRepository<Question>
    {
        Question GetByID(int id);
    }
}
