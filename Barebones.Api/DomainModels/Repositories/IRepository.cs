using System.Collections.Generic;

namespace Barebones.Api.DomainModels.Repositories
{
    public interface IRepository<TModel>
    {
        public IEnumerable<TModel> GetAll();
        public TModel Get(params object[] keys);
        public TModel Create(TModel model);
        public TModel Update(TModel model);
        public TModel Delete(TModel model);
    }
}