using BlogAPI.Context;
using BlogAPI.Models;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlogAPI.Features.Queries
{
    public class GetBlogByIdQuery : IRequest<blog>
    {
        public int Id { get; set; }
        public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery,blog >
        {
            private readonly Application_Context _context;
            public GetBlogByIdQueryHandler(Application_Context context)
            {
                _context = context;
            }
            public async Task<blog> Handle(GetBlogByIdQuery query, CancellationToken cancellationToken)
            {
                var product = _context.Blogs.Where(a => a.Id == query.Id).FirstOrDefault();
                if (product == null) return null;
                return product;
            }
        }
    }
}
