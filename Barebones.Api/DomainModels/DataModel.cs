namespace Barebones.Api.DomainModels
{
    public class DataModel<TKey, TModel>
    {
        public TKey Key { get; init; }
        public TModel Value { get; init; }
    }
}