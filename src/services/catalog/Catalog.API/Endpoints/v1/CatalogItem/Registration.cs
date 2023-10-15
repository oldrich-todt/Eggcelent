namespace Catalog.API.Endpoints.v1.CatalogItem
{
    public static class Registration
    {
        public static RouteGroupBuilder MapCatalogItemEndpoints(this RouteGroupBuilder builder)
        {
            var groupBuilder = builder.MapGroup("catalog-items");
            GetById.RegisterEndpoint(groupBuilder);
            return groupBuilder;
        }
    }
}
