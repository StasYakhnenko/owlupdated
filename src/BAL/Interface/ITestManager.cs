using Model.DTO;
using System.Collections.Generic;

namespace BAL.Interface
{
	public interface ITestManager
    {
        List<TestDTO> GetAll();
        TestDTO GetById(int id);
        int AddTest(TestDTO test);
        void UpdateTest(TestDTO test);
		void UpdateComplexity(TestDTO test);
        void AddQuestionToTest(QuestionDTO question, int id);
		string CheckComplexityForTest(TestDTO test);
		bool CheckUserAccess(int id, string userId);
		List<TestDTO> GetTestsForTeacher(string userId);
		List<TestDTO> GetTestsToPass();
		void AddRangeOfQuestions(int id, List<QuestionDTO> gottenQuestions);
	}
}
