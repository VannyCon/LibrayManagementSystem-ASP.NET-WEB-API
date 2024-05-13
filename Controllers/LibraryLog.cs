using Microsoft.AspNetCore.Mvc;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryLog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibraryLog : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LibraryLog(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<AttendanceController>

        [HttpGet(Name = "GetBooksLog")]
        public IActionResult Get()
        {
            try
            {
                var query = from bl in _context.tbl_borrow_log
                            join la in _context.log_authorization on bl.student_id_fk equals la.student_id
                            join tb in _context.tbl_book on bl.book_id equals tb.id
                            select new
                            {
                                id = bl.id,
                                student_id_fk = bl.student_id_fk,
                                student_fullname = la.fullname,
                                book_id = bl.book_id,
                                book_title = tb.book_title,
                                book_author = tb.book_author,
                                book_category = tb.book_category,
                                book_get_date = bl.book_get_date,
                                book_due_date = bl.book_due_date
                            };




                var result = query.ToList();

                if (result.Count == 0)
                {
                    return NotFound("List Notfound");
                }

                return Ok(result);
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
                var list = _context.tbl_borrow_log.Find(id);
                if (list == null)
                {
                    return NotFound("User not found on this id=" + id);
                }
                return Ok(new List<BooksLog> { list });
            }
            catch (Exception err)
            {

                return BadRequest(error: err.Message);
            }

        }
        [HttpPost(Name = "PostBooksLog")]
        public IActionResult Post(BooksLog model)
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

        [HttpPut(Name = "PutBooksLog")]
        public IActionResult Put(BooksLog model)
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

                var user = _context.tbl_borrow_log.Find(model.id);
                if (user == null)
                {
                    return BadRequest("User Id is invalid");
                }
                user.student_id_fk = model.student_id_fk;
                user.book_id = model.book_id;
                user.book_get_date = model.book_get_date;
                user.book_due_date = model.book_due_date;
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

                var user = _context.tbl_borrow_log.Find(id);

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
