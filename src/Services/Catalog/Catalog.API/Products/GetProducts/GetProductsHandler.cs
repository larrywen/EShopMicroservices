
using Catalog.API.Products.CreateProduct;
using JasperFx.Events.Daemon;

namespace Catalog.API.Products.GetProducts
{
    public record GetProductsQuery() : IQuery<GetProductsResult>;

    public record GetProductsResult(IEnumerable<Product> Product);
    internal class GetProductsQueryHandler(IDocumentSession session, ILogger<GetProductsQueryHandler> logger)
        : IQueryHandler<GetProductsQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductsQueryHandler.Handle called with {@query}", query);

            var poducts = await session.Query<Product>().ToListAsync(cancellationToken);

            //return result
            return new GetProductsResult(poducts);
        }
    }
}
