using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Ums.Core.Dto;
using Ums.Core.Models;
using Ums.Core.ViewModel;
using Ums.Manager;

namespace Ums.MvcApp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly StudentManager _studentManager;
        private readonly DepartmentManager _departmentManager;
        private readonly CourseManager _courseManager;

        public StudentsController()
        {
            _studentManager = new StudentManager();
            _departmentManager = new DepartmentManager();
            _courseManager = new CourseManager();
        }

        public ActionResult StudentList()
        {
            var students = _studentManager.GetAll().Select(Mapper.Map<Student, StudentViewModel>);
            return View(students);
        }

        public ActionResult StudentForm(int? id)
        {

            if (id != null)
            {
                var studentId = Convert.ToInt32(id);
                var student = _studentManager.GetById(studentId);


                ViewBag.DepartmentId = new SelectList(_departmentManager.GetAll(), "Id", "Name", student.DepartmentId);
                ViewBag.CourseId = new SelectList(_courseManager.GetCoursesByDepartment(student.DepartmentId), "Id", "Name", student.CourseId);
                return View(student);
            }

            ViewBag.DepartmentId = new SelectList(_departmentManager.GetAll(), "Id", "Name");
            ViewBag.CourseId = new SelectList(new List<Course>(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult StudentForm(StudentViewModel vm)
        {
            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                try
                {
                    ViewBag.DepartmentId = new SelectList(_departmentManager.GetAll(), "Id", "Name");
                    ViewBag.CourseId = new SelectList(new List<Course>(), "Id", "Name");

                    if (vm.Id == 0)
                    {
                        //save
                        var dto = Mapper.Map<StudentViewModel, StudentDto>(vm);
                        ViewBag.Message = _studentManager.Save(dto);
                        ModelState.Clear();
                        return View();

                    }
                    else
                    {
                        // update
                        ViewBag.Message = _studentManager.Update(vm.Id, vm);
                        ModelState.Clear();

                        var students = _studentManager.GetAll().Select(Mapper.Map<Student, StudentViewModel>);
                        return View("StudentList", students);
                    }

                }
                catch (Exception e)
                {
                    ViewBag.DepartmentId = new SelectList(_departmentManager.GetAll(), "Id", "Name", vm.DepartmentId);
                    ViewBag.CourseId = new SelectList(_courseManager.GetCoursesByDepartment(vm.DepartmentId), "Id", "Name", vm.CourseId);

                    ViewBag.Message = e.Message;
                    return View(vm);
                }
            }

            ViewBag.DepartmentId = new SelectList(_departmentManager.GetAll(), "Id", "Name", vm.DepartmentId);
            ViewBag.CourseId = new SelectList(_courseManager.GetCoursesByDepartment(vm.DepartmentId), "Id", "Name", vm.CourseId);

            return View(vm);
        }


        // GET: /Students/GetCourseByDepartment?departmentId=1
        public JsonResult GetCourseByDepartment(int departmentId)
        {
            var courses = _courseManager.GetCoursesByDepartment(departmentId);
            return Json(courses, JsonRequestBehavior.AllowGet);
        }
    }
}