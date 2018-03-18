using Model.DTO;

namespace BAL.Interface
{
	public interface IQuestionManager
    {
        QuestionDTO GetByID(int id);
        void UpdateQuestion(QuestionDTO model);
    }
}
