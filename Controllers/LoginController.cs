using System;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Login.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        // Inject IConfiguration to retrieve app settings
        public LoginController(IConfiguration configuration, ApplicationDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        // POST:
        [HttpPost("Request")]
        public ActionResult Login([FromBody] AccountModel model)
        {
            // Authenticate user (You will implement this logic)
            bool isAuthenticated = AuthenticateUser(model.username, model.password);

            if (isAuthenticated)
            {
                // Fetch user from database to get authorization
                var user = _context.log_authorization.FirstOrDefault(s => s.username == model.username);

                if (user != null)
                {
                    var authorization = user.authorization;
                    var username = user.username;
                    var studentid = user.student_id;
                    // Return token as response
                    return Ok(new { Authorization = authorization, Username = username, StudentId = studentid });
                }
                else
                {
                    // User not found
                    return NotFound("User not found");
                }
            }
            else
            {
                // Unauthorized
                return Unauthorized();
            }
        }


        private bool AuthenticateUser(string student_id, string password)
        {
            // Check if the user exists in the database and credentials are valid
            return _context.log_authorization.Any(s => s.username == student_id && s.password == password);
        }
    }
}
