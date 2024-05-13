
using System.ComponentModel.DataAnnotations;

public class Books
{
    [Key]
    public int id { get; set; }
    public string book_title { get; set; }
    public string book_author { get; set; }
    public string book_category { get; set; }
}
