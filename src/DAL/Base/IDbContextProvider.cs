using Microsoft.EntityFrameworkCore;

namespace DAL.Base
{
	public interface IDbContextProvider
    {
	    DbContext DbContext { get; }
	}
}
