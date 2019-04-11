using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Ums.Core.Dto;
using Ums.Core.Models;
using Ums.Core.ViewModel;
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

        public int Update(int id, StudentViewModel vm)
        {
            var studentInDb = _dbContext.Students.Find(id);
            if (studentInDb != null)
            {
                var createBy = studentInDb.CreateBy;
                var createDate = studentInDb.CreateDate;

                Mapper.Map(vm, studentInDb);
                studentInDb.CreateBy = createBy;
                studentInDb.CreateDate = createDate;

                return _dbContext.SaveChanges();

            }

            return 0;
        }

        //public int Update(Student s)

        public List<Student> GetAll()
        {
            return _dbContext.Students
                .Include(c => c.Department)
                .Include(c => c.Course)
                .Where(c => !c.IsDeleted).ToList();
        }


        public StudentViewModel GetById(int id)
        {
            var s = _dbContext.Students.Find(id);
            return Mapper.Map<Student, StudentViewModel>(s);
        }

        public int Delete(int id)
        {
            var s = _dbContext.Students.Find(id);
            if (s != null)
            {
                _dbContext.Students.Remove(s);
                return _dbContext.SaveChanges();
            }

            return 0;
        }
    }
}
