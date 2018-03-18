using Model.DTO;

namespace BAL.Interface
{
	public interface IImportQuestionsManager
    {
		QuestionsImportResultDTO ProccessFileForImport(string path);
	}
}
