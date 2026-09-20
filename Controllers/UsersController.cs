using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Models;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        // Static list to store users in memory for this lab
        private static readonly List<User> _users = new()
        {
            new User { Id = 1, Name = "Alice Brown", Email = "alice@example.com", Department = "Finance" },
            new User { Id = 2, Name = "Bob Smith", Email = "bob@example.com", Department = "IT" }
        };

        // GET: api/users
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(_users);
        }

        // GET: api/users/1
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound(new { error = "User not found" });
            }
            return Ok(user);
        }

        // POST: api/users
        [HttpPost]
        public ActionResult<User> CreateUser(User newUser) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var emailExists = _users.Any(u =>
                u.Email.Equals(newUser.Email, StringComparison.OrdinalIgnoreCase));

            if (emailExists)
            {
                return Conflict(new { error = "A user with this email already exists." });
            }

            newUser.Id = _users.Count > 0 ? _users.Max(u => u.Id) + 1 : 1;
            _users.Add(newUser);

            return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, newUser);
        }

        // PUT: api/users/1
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User updatedUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound(new { error = "User not found" });
            }

            var emailExists = _users.Any(u =>
                u.Id != id &&
                u.Email.Equals(updatedUser.Email, StringComparison.OrdinalIgnoreCase));

            if (emailExists)
            {
                return Conflict(new { error = "A user with this email already exists." });
            }

            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;
            user.Department = updatedUser.Department;

            return NoContent();
        }

        // DELETE: api/users/1
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound(new { error = "User not found" });
            }

            _users.Remove(user);
            return NoContent();
        }
    }
}