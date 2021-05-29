namespace Barebones.Api.DomainModels
{
    public class DataModel<TKey, TModel>
    {
        public TKey Key { get; set; }
        public TModel Value { get; set; }
    }
}