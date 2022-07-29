using BlogAPI.Context;
using BlogAPI.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BlogAPI.Features.Commands
{
    public class CreateBlogCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand,int>
        {
            private readonly Application_Context _context;
            public CreateBlogCommandHandler(Application_Context context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateBlogCommand command,CancellationToken cancellation)
            {
                var blog = new blog();
                blog.Title = command.Title;
                blog.Content = command.Content;
                _context.Blogs.Add(blog);
                await _context.SaveChanges();
                return blog.Id;
            }
        }
    }
}
