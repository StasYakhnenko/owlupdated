namespace DAL
{
	public interface IUnitOfWork
	{
		void Begin();

		void Commit();
	}
}
