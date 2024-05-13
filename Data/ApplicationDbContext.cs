// Data/ApplicationDbContext.cs

using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    public DbSet<AccountModel> log_authorization { get; set; }
    public DbSet<Books> tbl_book { get; set; }
    public DbSet<BooksLog> tbl_borrow_log { get; set; }

    
}
