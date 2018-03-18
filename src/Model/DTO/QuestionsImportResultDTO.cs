using System.Collections.Generic;

namespace Model.DTO
{
	public class QuestionsImportResultDTO
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string SubjectName { get; set; }
		public int QuestionsCount { get; set; }
		public string[] ErrorMessage { get; set; }
		public bool IsSuccessful { get; set; }
		public List<QuestionDTO> GottenQuestions { get; set; }
    }
}
