using ReactProject.Infrastructure;
using ReactProject.Models;

namespace ReactProject.Repository
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
    }

    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(StudentDbContext context) : base(context)
        {

        }
    }
}