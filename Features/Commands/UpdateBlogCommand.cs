using BlogAPI.Context;
using BlogAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
namespace BlogAPI.Features.Commands
{
    public class UpdateBlogCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand,int>
        {
            private readonly Application_Context _context;
            public UpdateBlogCommandHandler(Application_Context context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateBlogCommand command,CancellationToken cancellationToken)
            {
                var blog = _context.Blogs.Where(x=>x.Id == command.Id).FirstOrDefault();
                if (blog == null)
                {
                    return default;
                }
                blog.Title = command.Title;
                blog.Content = command.Content;
                await _context.SaveChanges();
                return command.Id;
                
            }
        }
    }
}
