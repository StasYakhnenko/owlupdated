using Common;
using System;
using System.Collections.Generic;

namespace Model.DTO
{
	public class TestDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }
        public double Requirment { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool ConsiderPartialAnswers { get; set; }
        public int SubjectId { get; set; }
        public byte TimeLimit { get; set; }
		public TestStatus Status { get; set; }
		public OpenTest OpenStatus { get; set; }
		public int CountOfQuestions { get; set; }
		public int CountOfEasy { get; set; }
		public int CountOfMedium { get; set; }
		public int CountOfHard { get; set; }
		public SubjectDTO Subject { get; set; }
        public ICollection<QuestionDTO> Questions { get; set; }
        public IEnumerable<SubjectDTO> Subjects { get; set; }
        public IEnumerable<UserDTO> Teachers { get; set; }
        public IEnumerable<UserDTO> TeachersAll { get; set; }
        public string TeachersJSON { get; set; }
    }
}
