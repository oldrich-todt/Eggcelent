using Catalog.Application.Features.GetCatalogItemById;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Catalog.API.Endpoints.v1.CatalogItem
{
    public static class GetById
    {
        private static async Task<Ok<GetCatalogItemByIdResponse>> Endpoint(IMediator mediator, Guid id)
        {
            var command = new GetCatalogItemByIdCommand { Id = id };

            var result = await mediator.Send(command);

            return TypedResults.Ok(result);
        }

        public static void RegisterEndpoint(RouteGroupBuilder builder)
        {
            builder.MapGet("{id}", Endpoint);
        }
    }
}
