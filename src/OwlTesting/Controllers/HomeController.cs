using Microsoft.AspNetCore.Mvc;
using BAL.Interface;
using Microsoft.AspNetCore.Authorization;
using Model.DTO;
using Microsoft.AspNetCore.Identity;
using Model.DB;

namespace OwlTesting.Controllers
{
	public class HomeController : Controller
    {
		private readonly ISubjectManager subjectManager;
		private readonly ITestResultManager testResultManager;
		private UserManager<ApplicationUser> userIdenityManager;

		public HomeController(
			ISubjectManager subjectManager,
			UserManager<ApplicationUser> userIdenityManager,
			ITestResultManager testResultManager)
		{
			this.subjectManager = subjectManager;
			this.testResultManager = testResultManager;
			this.userIdenityManager = userIdenityManager;
		}
		[AllowAnonymous]
        public IActionResult Index()
        {
			var subjects = subjectManager.GetAll();

			System.Security.Claims.ClaimsPrincipal currentUser = this.User;
			string userId = userIdenityManager.GetUserId(currentUser);
			var openTests = testResultManager.GetOpenTests(userId);
			var model = new HomePageDTO
			{
				Subjects = subjects,
				OpenTests = openTests
			};

			return View(model);
        }
    }
}
