namespace DAL.Interface
{
	public interface IUnitOfWorkOld
    {
		ISubjectRepository SubjectRepo { get; }
        ITestRepository TestRepo { get; }
		IAnswerRepository AnswerRepo { get; }
        IQuestionRepository QuestionRepo { get; }
		IUserRepository UserRepo { get; }
        ITestResultRepository TestResultRepo { get; }
        void Dispose();

        int Save();
    }
}
