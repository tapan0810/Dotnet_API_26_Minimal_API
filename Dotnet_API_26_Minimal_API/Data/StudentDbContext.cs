using Dotnet_API_26_Minimal_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_API_26_Minimal_API.Data
{
    public class StudentDbContext:DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) { }

        public DbSet<Student> Students => Set<Student>();
    }
}
