using AccountMicroservice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountMicroservice.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private static List<User> Users = new List<User>
        {
            new User
            {
                Id = 1,
                Email = "rm84911@fiap.com.br",
                Name = "Gabriel Aguiar",
                Password = "1234"
            },
            new User
            {
                Id = 2,
                Email = "rm85159@fiap.com.br",
                Name = "Lucas Blotta",
                Password = "2345"
            },
            new User
            {
                Id = 3,
                Email = "rm84911@fiap.com.br",
                Name = "Guilherme Bustos",
                Password = "3456"
            },
        };

        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        // GET: <AccountController>
        [HttpGet("")]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(Users);
        }

        // GET <AccountController>/5
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var u = Users.Find(u => u.Id == id);
            if (u == null)
            {
                return NotFound();
            }
            return Ok(u);
        }

        // POST <AccountController>
        [HttpPost]
        public ActionResult<User> RegisterUser([FromBody] User user)
        {
            user.Id = new Random().Next();
            Users.Add(user);
            return Ok(user);
        }

        // PUT <AccountController>/5
        [HttpPut("{id}")]
        public ActionResult<User> UpdateUser(int id, [FromBody] User user)
        {
            var u = Users.Find(u => u.Id == id);
            if (u == null)
            {
                return BadRequest();
            }

            u.Name = user.Name;
            u.Password = user.Password;
            u.Email = u.Email;

            return Ok(u);
        }

        // DELETE <AccountController>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var u = Users.Find(u => u.Id == id);
            if (u == null)
            {
                return NotFound();
            }

            Users.Remove(u);
            return NoContent();
        }
    }
}
