using DEKODE.AttendMe.Api.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEKODE.AttendMe.Api.Repositories
{
    public interface IStudentRepository
    {
        Task<IList<Student>> GetAllAsync(int organisationId);

        Task<Student> GetByIdAsync(int studentId);

        Task<bool> SaveStudent(Student student);

        Task<bool> DeleteStudent(int studentId, int organisationId);
    }
}