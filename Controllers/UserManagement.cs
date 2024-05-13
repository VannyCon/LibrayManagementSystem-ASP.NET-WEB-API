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
    public class UserManagement : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        // Inject IConfiguration to retrieve app settings
        public UserManagement(IConfiguration configuration, ApplicationDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }




        [HttpGet(Name = "GetUser")]
        public IActionResult Get()
        {
            try
            {
                var list = _context.log_authorization.ToList();
                if (list.Count == 0)
                {
                    return NotFound("List Notfound");
                }
                return Ok(list);
            }
            catch (Exception e)
            {

                return BadRequest(error: e.Message);
            }

        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var list = _context.log_authorization.Find(id);
                if (list == null)
                {
                    return NotFound("User not found on this id=" + id);
                }
                return Ok(new List<AccountModel> { list });
            }
            catch (Exception err)
            {

                return BadRequest(error: err.Message);
            }

        }
        [HttpPost(Name = "CreateUser")]
        public IActionResult Post(AccountModel model)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();
                return Ok("User Created");
            }
            catch (Exception e)
            {

                return BadRequest(error: e.Message);
            }
        }

        [HttpPut(Name = "UpdateUser")]
        public IActionResult Put(AccountModel model)
        {
            try
            {

                if (model == null)
                {
                    return BadRequest("Model data is invalid");
                }
                else if (model.id == null)
                {
                    return BadRequest("User Id is invalid");
                }

                var user = _context.log_authorization.Find(model.id);
                if (user == null)
                {
                    return BadRequest("User Id is invalid");
                }
                user.student_id = model.student_id;
                user.username = model.username;
                user.password = model.password;
                user.fullname = model.fullname;
                user.authorization = model.authorization;
                _context.SaveChanges();
                return Ok("User Updated");
            }

            catch (Exception e)
            {

                return BadRequest(error: e.Message);
            }

        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {

                var user = _context.log_authorization.Find(id);

                if (user == null)
                {
                    return BadRequest("Model data is invalid");
                }
                _context.Remove(user);
                _context.SaveChanges();
                return Ok("Successfully Deleted " + id);
            }
            catch (Exception e)
            {

                return BadRequest(error: e.Message);
            }

        }
    }
}
