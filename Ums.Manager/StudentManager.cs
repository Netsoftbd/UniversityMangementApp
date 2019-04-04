using System;
using System.Collections.Generic;
using System.Linq;
using Ums.Core.Dto;
using Ums.Core.Models;
using Ums.Persistancis.Repositories;

namespace Ums.Manager
{
    public class StudentManager
    {
        private readonly StudentRepository _studentRepository;

        public StudentManager()
        {
            _studentRepository = new StudentRepository();
        }

        public string Save(StudentDto dto)
        {
            var isRollExist = IsRollExist(dto.Roll);
            if (isRollExist)
            {
                throw new ApplicationException("Student Roll Already Exist");
            }

            var result = _studentRepository.Save(dto);
            if (result > 0)
                return "Save Success";
            return "Save Fail";
        }

        public bool IsRollExist(string roll)
        {
            bool isRollExist = false;
            var students = _studentRepository.GetAll().SingleOrDefault(c => c.Roll == roll);
            if (students != null)
            {
                isRollExist = true;
            }

            return isRollExist;
        }

        public List<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }
    }
}