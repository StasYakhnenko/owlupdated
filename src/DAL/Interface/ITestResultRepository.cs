using Model.DB;
using System.Collections.Generic;

namespace DAL.Interface
{
	public interface ITestResultRepository : IGenericRepository<TestResult>
    {
        TestResult GetByID(int id);
        void SetAnswerToQuestion(int testId, int questionId, List<int> answerId);
        IEnumerable<TestResult> GetAll();
        IEnumerable<TestResult> GetBySubjectId(int subjectId);
        IEnumerable<TestResult> GetByUserId(string userId);
        void SetQuestionsToTestResult(int testId);
    }
}
