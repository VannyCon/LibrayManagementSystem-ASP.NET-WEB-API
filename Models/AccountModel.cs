
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class AccountModel
{
    [Key]
    public int id { get; set; }
    public int? student_id { get; set; }
    public string? authorization { get; set; }
    public string? fullname { get; set; }
    public string username { get; set; }
    public string password { get; set; }
}
