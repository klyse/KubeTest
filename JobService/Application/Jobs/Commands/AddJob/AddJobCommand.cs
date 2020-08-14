using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Application.Jobs.Commands.AddJob
{
	public class AddJobCommand : IRequest
	{
		public class Handler : IRequestHandler<AddJobCommand, Unit>
		{
			public Task<Unit> Handle(AddJobCommand request, CancellationToken cancellationToken)
			{
				return Unit.Task;
			}
		}
	}
}