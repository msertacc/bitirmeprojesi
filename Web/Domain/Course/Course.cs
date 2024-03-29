﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entity.Domain.Course
{

    [Table("Course")]
    public class Course:BaseEntity.BaseEntity
    {
        [Required]
        public virtual string? Name { get; set; }

        public List<Exam.Exam>? Exams { get; set; }
		public List<StudentCourse.StudentCourse>? StudentCourses { get; set; }

    }
}
