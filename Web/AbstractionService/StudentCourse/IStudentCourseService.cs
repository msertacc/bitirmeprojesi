using Entity.Dto.Course;
using Entity.Dto.Exam;
using Entity.Dto.StudentCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.Service.StudentCourse
{
    public interface IStudentCourseService
    {
        List<StudentCourseDto> GetStudentCourse(Guid userId);

        StudentCourseDto GetStudentCourseById(int id);

        Task<StudentCourseDto> Create(StudentCourseDto studentCourseDto);

        Task Update(StudentCourseDto studentCourseDto);

        Task Delete(int id);
    }
}
