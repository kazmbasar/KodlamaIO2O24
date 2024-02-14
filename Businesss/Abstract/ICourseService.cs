using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICourseService
    {
        IDataResult<List<Course>> GetAll();
        IDataResult<List<Course>> GetAllByCategoryId(int categoryId);
        IDataResult<List<CourseDetailDto>> GetCourseDetails();
        IDataResult<List<Course>> GetAllByInstructorId(int instructorId);
        IResult Add(Course course);
        IResult Delete(Course course);
        IResult Update(Course course);

    }
}
