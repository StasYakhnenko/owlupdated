using Model.DTO;
using System.Collections.Generic;

namespace BAL.Interface
{
	public interface ISubjectManager
    {
        List<SubjectDTO> GetAll();

        int AddSubject(SubjectDTO subject);

        bool DeleteSubject(int id);

        bool UpdateSubject(SubjectDTO subject);

        SubjectDTO GetById(int id);
    }
}
