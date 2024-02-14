using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete
{
    public class EfCourseDal : EfEntityRepositoryBase<Course, CourseDbContext>, ICourseDal
    {
        public List<CourseDetailDto> GetCourseDetails()
        {
            using (CourseDbContext context = new CourseDbContext())
            {
                var result = from c in context.Courses
                             join ca in context.Categories
                             on c.CategoryId equals ca.Id
                             join i in context.Instructors
                             on c.InstructorId equals i.Id
                             select new CourseDetailDto
                             {
                                 CategoryName = ca.Name,
                                 CourseId = c.Id,
                                 CourseName = c.Name,
                                 Description = c.Description,
                                 InstruductorName = i.FirstName + " " + i.LastName





                             };
                return result.ToList();
            }

        }

    }
}
