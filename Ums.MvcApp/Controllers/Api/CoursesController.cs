using System.Web.Http;
using Ums.Core.Models;
using Ums.Manager;

namespace Ums.MvcApp.Controllers.Api
{
    public class CoursesController : ApiController
    {
        private readonly CourseManager _courseManager;

        public CoursesController()
        {
            _courseManager = new CourseManager();
        }

        public IHttpActionResult Get()
        {
            return Ok(_courseManager.Get());
        }

        // GET: api/Courses/GetByDepartment
        [Route("api/Courses/GetByDepartment")]
        public IHttpActionResult GetByDepartment(int departmentId)
        {
            var courses = _courseManager.GetCoursesByDepartment(departmentId);
            return Ok(courses);
        }

        // GET: api/Courses/5
        public IHttpActionResult Get(int id)
        {
            return Ok();
        }

        // POST: api/Courses
        public IHttpActionResult Post([FromBody]Course c)
        {
            var success = _courseManager.Save(c);
            return Ok(success);
        }

        // PUT: api/Courses/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Courses/5
        public void Delete(int id)
        {
        }
    }
}
