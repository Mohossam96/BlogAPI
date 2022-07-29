using BlogAPI.Context;
using BlogAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BlogAPI.Features.Queries
{
    public class GetAllBlogsQuery : IRequest<IEnumerable<blog>>
    {
        public class GetAllBlogsQueryHandler : IRequestHandler<GetAllBlogsQuery, IEnumerable<blog>>
        {
            private readonly Application_Context _context;
            public GetAllBlogsQueryHandler(Application_Context context)
            {
                _context = context;
            }
            public async Task<IEnumerable<blog>> Handle(GetAllBlogsQuery query, CancellationToken cancellationToken)
            {
                var productList = await _context.Blogs.ToListAsync();
                if (productList == null)
                {
                    return null;
                }
                return productList.AsReadOnly();
            }
        }
    }
}
