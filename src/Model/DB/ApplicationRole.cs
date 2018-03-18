using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Model.DB
{
	public class ApplicationRole : IdentityRole
    {
        public string Describtion { get; set; }
    }
}
