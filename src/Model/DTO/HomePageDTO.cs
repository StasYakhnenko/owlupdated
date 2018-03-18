using System.Collections.Generic;

namespace Model.DTO
{
	public class HomePageDTO
    {
		public List<TestResultDTO> OpenTests { get; set; }
		public List<SubjectDTO> Subjects { get; set; }
	}
}
