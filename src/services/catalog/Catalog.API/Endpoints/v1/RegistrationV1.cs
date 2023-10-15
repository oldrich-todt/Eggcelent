using Catalog.API.Endpoints.v1.CatalogItem;

namespace Catalog.API.Endpoints.v1
{
    public static class RegistrationV1
    {
        public static RouteGroupBuilder MapV1(this WebApplication app)
        {
            var groupBuilder = app.MapGroup("v1");
            groupBuilder.MapCatalogItemEndpoints();
            groupBuilder.WithOpenApi();
            return groupBuilder;
        }
    }
}
