using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Application.Common.Exceptions;
using Catalog.Domain.Aggregates.CatalogItemAggregate;
using Catalog.Domain.Specifications;
using Eggcelent.SharedKernel;
using MediatR;

namespace Catalog.Application.Features.GetCatalogItemById
{
    public record GetCatalogItemByIdCommand: IRequest<GetCatalogItemByIdResponse>
    {
        public required Guid Id { get; init; }
    }

    public record GetCatalogItemByIdResponse
    {
        public required Guid Id { get; init; }
        public required string Name { get; init; }
    }

    public class GetCatalogItemByIdCommandHandler : IRequestHandler<GetCatalogItemByIdCommand, GetCatalogItemByIdResponse>
    {
        private readonly IReadOnlyRepository<CatalogItem> catalogItemRepository;

        public GetCatalogItemByIdCommandHandler(IReadOnlyRepository<CatalogItem> catalogItemRepository)
        {
            this.catalogItemRepository = catalogItemRepository;
        }

        public async Task<GetCatalogItemByIdResponse> Handle(GetCatalogItemByIdCommand request, CancellationToken cancellationToken)
        {
            var catalogItem = await catalogItemRepository.FirstOrDefaultAsync(new GetCatalogItemByIdSpecification(request.Id), cancellationToken);

            if(catalogItem == null)
            {
                throw new CatalogItemNotFoundException(request.Id);
            }

            return new GetCatalogItemByIdResponse
            {
                Id = catalogItem.Id,
                Name = catalogItem.Name,
            };
        }
    }
}
