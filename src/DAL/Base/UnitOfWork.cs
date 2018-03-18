using System.Globalization;
using DAL.Base;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly DbContext _dbContext;

		public string ConnectionString { get; }

		public DbContext DbContext => _dbContext;

		public string Language => CultureInfo.CurrentCulture.TwoLetterISOLanguageName;

		public UnitOfWork(IDbContextProvider dbContextProvider)
		{
			_dbContext = dbContextProvider.DbContext;
			ConnectionString = _dbContext.Database.GetDbConnection().ConnectionString;
		}
		public void Begin()
		{
		}
		public void Commit()
		{
			this._dbContext.SaveChanges();
		}
	}
}
