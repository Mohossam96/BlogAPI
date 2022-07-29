using BlogAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BlogAPI.Context
{
    public interface IApplication_Context
    {
        DbSet<blog> Blogs { get; set; }
        public Task<int> SaveChanges();
    }
}