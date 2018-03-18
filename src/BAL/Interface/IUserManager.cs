using Model.DTO;
using System.Collections.Generic;

namespace BAL.Interface
{
	public interface IUserManager
    {
        List<UserDTO> GetAllTeachers();
        UserDTO GetById(string id);
    }
}
