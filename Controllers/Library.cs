using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Library : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public Library(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<AttendanceController>

        [HttpGet(Name = "GetBook")]
        public IActionResult Get()
        {
            try
            {
                var list = _context.tbl_book.ToList();
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
                var list = _context.tbl_book.Find(id);
                if (list == null)
                {
                    return NotFound("User not found on this id=" + id);
                }
                return Ok(new List<Books> { list });
            }
            catch (Exception err)
            {

                return BadRequest(error: err.Message);
            }

        }
        [HttpPost(Name = "PostBooks")]
        public IActionResult Post(Books model)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();
                return Ok("Book Created");
            }
            catch (Exception e)
            {

                return BadRequest(error: e.Message);
            }

        }

        [HttpPut(Name = "PutBooks")]
        public IActionResult Put(Books model)
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

                var user = _context.tbl_book.Find(model.id);
                if (user == null)
                {
                    return BadRequest("User Id is invalid");
                }
                user.book_title = model.book_title;
                user.book_author = model.book_author;
                user.book_category = model.book_category;
                _context.SaveChanges();
                return Ok("Item Updated");
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

                var user = _context.tbl_book.Find(id);

                if (user == null)
                {
                    return BadRequest("Model data is invalid");
                }
                _context.Remove(user);
                _context.SaveChanges();
                return Ok("Successfully Deleted " + user);
            }
            catch (Exception e)
            {

                return BadRequest(error: e.Message);
            }

        }

    } 
}
