using BlogAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BlogAPI.Context
{
    public class Application_Context : DbContext
    {
        public DbSet<blog> Blogs { get; set; }

        public Application_Context(DbContextOptions<Application_Context> options) : base(options)
        {

        }
        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
