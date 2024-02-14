using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CourseManager : ICourseService
    {
        private readonly ICourseDal? _courseDal;
        public CourseManager(ICourseDal courseDal)
        {
            _courseDal = courseDal;
        }
        public IResult Add(Course course)
        {
            if (course.Name.Length < 3)
            {
                return new ErrorResult(Messages.InvalidCourseName);
            }
            _courseDal.Add(course);
            return new Result(true, Messages.CourseAdded);
        }

        public IResult Delete(Course course)
        {
            _courseDal.Delete(course);
            return new Result(true, Messages.CourseDeleted);
        }
        IDataResult<List<Course>> ICourseService.GetAllByInstructorId(int instructorId)
        {
            return new SuccessDataResult<List<Course>>(_courseDal.GetAll(c => c.InstructorId == instructorId));
        }

        public IDataResult<List<Course>> GetAll()
        {
            return new SuccessDataResult<List<Course>>(_courseDal.GetAll(), Messages.CourseListed);
        }

        public IDataResult<List<Course>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Course>>(_courseDal.GetAll(c => c.CategoryId == id));
        }

        public IDataResult<List<CourseDetailDto>> GetCourseDetails()
        {
            return new SuccessDataResult<List<CourseDetailDto>>(_courseDal.GetCourseDetails());
        }

        public IResult Update(Course course)
        {
            _courseDal.Update(course);
            return new Result(true, Messages.CourseUpdated);
        }


    }
}
