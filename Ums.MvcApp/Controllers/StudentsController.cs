using AutoMapper;
using System;
using System.Collections.Generic;
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

        // GET: Students
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult StudentForm()
        {
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

                    var dto = Mapper.Map<StudentViewModel, StudentDto>(vm);
                    ViewBag.Message = _studentManager.Save(dto);
                    ModelState.Clear();
                    return View();
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