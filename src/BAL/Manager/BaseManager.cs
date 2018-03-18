using DAL.Interface;

namespace BAL.Manager
{
	public class BaseManager
    {
        protected IUnitOfWorkOld uOw;

        public BaseManager(IUnitOfWorkOld uOw)
        {
            this.uOw = uOw;
        }
    }
}
