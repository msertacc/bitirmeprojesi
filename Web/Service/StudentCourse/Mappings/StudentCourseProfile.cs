using AutoMapper;
using Entity.Dto.Course;
using Entity.Dto.StudentCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.StudentCourse.Mappings
{
    public class StudentCourseProfile:Profile
    {
        public StudentCourseProfile()
        {
            this.CreateMap<Entity.Domain.StudentCourse.StudentCourse, StudentCourseDto>();
            this.CreateMap<StudentCourseDto, Entity.Domain.StudentCourse.StudentCourse>();
        }
    }
}
