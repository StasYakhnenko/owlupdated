using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OwlTesting.ViewModels
{
	public class EditUserViewModel
    {
        public string Id { get; set; }
		[Display(Name = "Нікнейм")]
        public string Name { get; set; }
		[Display(Name = "Ім'я")]
		public string FirstName { get; set; }
		[Display(Name = "Прізвище")]
		public string LastName { get; set; }
	    [Display(Name = "Пароль")]
		public string PasswordForShow { get; set; }
	    public string OldPassword { get; set; }
		[Display(Name = "Номер групи (якщо користувач - студент)")]
		public int? Group { get; set; }
		[Display(Name = "Номер залікової книжки")]
		public string StudentId { get; set; }
		[Display(Name = "Дата початку навчання")]
		public DateTime? StudyStartDate { get; set; }
		[Display(Name = "Дата завершення навчання")]
		public DateTime? StudyEndDate { get; set; }
		[Display(Name = "Електрона пошта")]
		public string Email { get; set; }
        public List<SelectListItem> ApplicationRoles { get; set; }
        [Display(Name = "Роль")]
        public string ApplicationRoleId { get; set; }
    }
}
