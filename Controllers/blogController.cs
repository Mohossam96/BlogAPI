using BlogAPI.Features.Commands;
using BlogAPI.Features.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class blogController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpPost]
        public async Task<IActionResult>Create(CreateBlogCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllBlogsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            return Ok(await Mediator.Send(new GetBlogByIdQuery { Id = id }));

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete (int id)
        {
            return Ok (await Mediator.Send(new DeleteBlogCommand { Id = id })); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,UpdateBlogCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            return Ok(await Mediator.Send(command));
        }
    }
}
