
using System.ComponentModel.DataAnnotations;

public class BooksLog
{
    [Key]
    public int id { get; set; }
    public int student_id_fk { get; set; }
    public int book_id { get; set; }
    public string book_get_date { get; set; }
    public string book_due_date { get; set; }
}

