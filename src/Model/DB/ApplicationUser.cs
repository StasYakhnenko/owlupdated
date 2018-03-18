using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Model.DB
{
	public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
		public string StudentId { get; set; }
		public DateTime? StudyStartDate { get; set; }
		public DateTime? StudyEndDate { get; set; }
		public int? Group { get; set; }
	    public string PasswordForShow { get; set; }
        public virtual ICollection<TeacherTest> TeacherTests { get; set; }
        public virtual ICollection<TestResult> TestHistory { get; set; }
    }
}
