using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Ums.Core.Dto;
using Ums.Core.Models;
using Ums.Persistancis.DatabaseFile;

namespace Ums.Persistancis.Repositories
{
    public class StudentRepository
    {
        private readonly UniversityDbContext _dbContext = new UniversityDbContext();

        public int Save(StudentDto dto)
        {
            // query
            var s = Mapper.Map<StudentDto, Student>(dto);

            s.CreateBy = "admin";
            s.CreateDate = DateTime.Now;

            //var student = new Student()
            //{
            //    Name = dto.Name,
            //    Roll = dto.Roll,
            //    Reg = dto.Reg,
            //    CreateBy = "Admin",
            //    CreateDate = DateTime.Now
            //};

            _dbContext.Students.Add(s);

            //command
            _dbContext.SaveChanges();

            //result
            return s.Id;
        }

        //public int Update(Student s)

        public List<Student> GetAll()
        {
            return _dbContext.Students.Where(c => !c.IsDeleted).ToList();
        }


    }
}
