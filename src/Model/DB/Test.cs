using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Model.DB
{
	public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }
        public double Requirment { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool ConsiderPartialAnswers { get; set; }
        public byte TimeLimit { get; set; }
        public int SubjectId { get; set; }
		public TestStatus Status { get; set; }
		public OpenTest OpenStatus { get; set; }
		public int CountOfQuestions { get; set; }
		public int CountOfEasy { get; set; }
		public int CountOfMedium { get; set; }
		public int CountOfHard { get; set; }
		public virtual Subject Subject { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<TeacherTest> TeacherTests { get; set; }
        public virtual ICollection<TestResult> TestHistory { get; set; }

		[NotMapped]
		public virtual List<Question> EasyQuestions => Questions?.Where(x => x.Level == ComplexityLevel.Easy).ToList();
		[NotMapped]
		public virtual List<Question> MediumQuestions => Questions?.Where(x => x.Level == ComplexityLevel.Medium).ToList();
		[NotMapped]
		public virtual List<Question> HardQuestions => Questions?.Where(x => x.Level == ComplexityLevel.Hard).ToList();
	}
}
