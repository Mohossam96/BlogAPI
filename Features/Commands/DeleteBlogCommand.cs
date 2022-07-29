using BlogAPI.Context;
using BlogAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlogAPI.Features.Commands
{
    public class DeleteBlogCommand :IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand,int>
        {
            private readonly Application_Context _context;
            public DeleteBlogCommandHandler(Application_Context context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteBlogCommand command,CancellationToken cancellation)
            {
                var blog = await _context.Blogs.Where(x => x.Id == command.Id).FirstOrDefaultAsync();
                if (blog == null) return default;
                _context.Blogs.Remove(blog);
                await _context.SaveChanges();
                return blog.Id;
            }
        }
    }
}
