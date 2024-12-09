using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BASIC.Models
{
    public class Person
    {
        [Key]
        public string? PersonId { get; set; }
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        public int? Age { get; set; }


    }

    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        public DbSet<Person> Person { get; set; }
    }
}
