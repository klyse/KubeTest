using System.Threading.Tasks;
using Application.Jobs.Commands.AddJob;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobService.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class JobsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public JobsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<ActionResult<string>> Post()
		{
			return await _mediator.Send(new AddJobCommand());
		}
	}
}