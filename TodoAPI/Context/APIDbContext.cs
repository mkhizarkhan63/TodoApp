using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using TodoAPI.Models;

namespace TodoAPI.Context
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {

        }
        public DbSet<TodoTask> TodoTasks { get; set; }
    }
}
