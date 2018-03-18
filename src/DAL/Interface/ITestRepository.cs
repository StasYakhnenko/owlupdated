using Model.DB;
using System.Collections.Generic;

namespace DAL.Interface
{
	public interface ITestRepository : IGenericRepository<Test>
    {
        Test GetByID(int id);
        IEnumerable<Test> GetAll();
    }
}
