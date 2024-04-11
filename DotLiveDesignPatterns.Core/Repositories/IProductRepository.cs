namespace DotLiveDesignPatterns.Core.Repositories;

public interface IProductRepository
{
    bool HasStock(Dictionary<Guid, int> items);
}