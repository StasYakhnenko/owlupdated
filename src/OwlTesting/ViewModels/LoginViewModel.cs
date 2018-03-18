using System.ComponentModel.DataAnnotations;

namespace OwlTesting.ViewModels
{
	public class LoginViewModel
    {
        [Required]
		[Display(Name ="Логін")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
		[Display(Name = "Пароль")]
		public string Password { get; set; }
		[Display(Name = "Запам'ятайте мене")]
		public bool RememberMe { get; set; }
    }
}
