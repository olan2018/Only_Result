using System.Collections.Generic;
using System.Linq;
using Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Application.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserContext _userContext;

        public UsersController(UserContext userContext)
        {
            _userContext = userContext;
        }

        [Route("api/[controller]/GetAllStudents")]
        [HttpGet]
        public ActionResult<IEnumerable<StudentItem>> GetAllStudents()
        {
            return _userContext.StudentItems
                .Include(x => x.User)
                .ToList();
        }

        [Route("api/[controller]/GetStudent/{login}")]
        [HttpGet]
        public ActionResult<StudentItem> GetStudent(string login)
        {
            return _userContext.StudentItems.Include(x => x.User).SingleOrDefault(x => x.User.Login == login);
        }

        [Route("api/[controller]/UpdateStudent")]
        [HttpPost]
        public ActionResult<bool> CreateStudent(StudentItem student)
        {
            var studentDb = _userContext.StudentItems.Include(x => x.User).SingleOrDefault(x => x.ID == student.ID);
            studentDb = student;
            _userContext.SaveChanges();

            return true;
        }

        [Route("api/[controller]/DeleteStudent/{login}")]
        [HttpGet]
        public ActionResult<bool> DeleteStudent(string login)
        {
            var studentDb = _userContext.StudentItems.Include(x => x.User).SingleOrDefault(x => x.User.Login == login);
            if (studentDb != null)
            {
                _userContext.Remove(studentDb);
                _userContext.SaveChanges();
                return true;
            }
            
            return false;
        }
    }
}