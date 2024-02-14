using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;

namespace Business.Concrete
{
    public class InstructorManager : IInstructorService
    {
        private readonly IInstructorDal? _instructorDal;
        public InstructorManager(IInstructorDal instructorDal)
        {
            _instructorDal = instructorDal;
        }
        public IResult Add(Instructor instructor)
        {
            _instructorDal.Add(instructor);
            return new Result(true);
        }

        public IResult Delete(Instructor instructor)
        {
            _instructorDal?.Delete(instructor);
            return new Result(true);
        }

        public IDataResult<List<Instructor>> GetAll()
        {
            return new SuccessDataResult<List<Instructor>>(_instructorDal.GetAll());
        }

        public IResult Update(Instructor instructor)
        {
            _instructorDal.Update(instructor);

            return new Result(true);
        }
    }
}
