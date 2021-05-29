
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Barebones.Api.DomainModels.Repositories
{
    public class InMemoryRepository<TKey, TModel> : IRepository<TModel>
        where TModel : DataModel<TKey, TModel>

    {
        private ConcurrentDictionary<TKey, TModel> _concurrentDictionary = new ConcurrentDictionary<TKey, TModel>();

        public IEnumerable<TModel> GetAll() => _concurrentDictionary.Values;

        public TModel Get(params object[] keys)
        {
            foreach (var key in keys)
            {
                if (_concurrentDictionary.TryGetValue((TKey) key, out var found))
                {
                    return found;
                }
            }

            return default;
        }

        public TModel Create(TModel model) =>
            _concurrentDictionary.TryAdd(model.Key, model.Value) ? model : default;

        public TModel Update(TModel model) =>
            _concurrentDictionary.TryUpdate(model.Key, model.Value, Get(model.Key)) ? model : default;

        public TModel Delete(TModel model) =>
            _concurrentDictionary.TryRemove(model.Key, out var deleted) ? deleted : default;
    }
}