namespace Basket.API.Basket.GetBasket;

public record GetBasketQuery(string UserName) : IQuery<GetBasketResult>;  // add project reference to BuildingBlock project
public record GetBasketResult(ShoppingCart Cart);
public class GetBasketQueryHandler(IBasketRepository repository) // represent business logics, mapping handle class to the application layer in clean architecture
    : IQueryHandler<GetBasketQuery, GetBasketResult>
{
    public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
    {
        //TODO: get basket from database
        var basket = await repository.GetBasket(query.UserName);

        return new GetBasketResult(basket);
    }
}
