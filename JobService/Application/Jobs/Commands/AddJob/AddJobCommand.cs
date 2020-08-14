using System.Threading;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Application.Jobs.Commands.AddJob
{
	public class AddJobCommand : IRequest<string>
	{
		public class Handler : IRequestHandler<AddJobCommand, string>
		{
			private readonly IConfiguration _config;

			public Handler(IConfiguration config)
			{
				_config = config;
			}

			public async Task<string> Handle(AddJobCommand request, CancellationToken cancellationToken)
			{
				var baseUrl = _config.GetSection("RandomService:BaseUrl").Value;

				var res = await baseUrl.AppendPathSegment("/random")
					.SetQueryParam("min", "10")
					.SetQueryParam("max", "100")
					.GetAsync(cancellationToken);


				return await res.Content.ReadAsStringAsync();
			}
		}
	}
}