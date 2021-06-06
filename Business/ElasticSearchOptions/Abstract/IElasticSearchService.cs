using Nest;
using System.Threading.Tasks;
using Entity.ElasticEntity.Concrete;

namespace Business.ElasticSearchOptions.Abstract
{
    public interface IElasticSearchService
    {
        Task<ISearchResponse<T>> SimpleSearchAsync<T, TKey>(string indexName, SearchDescriptor<T> query) where T : ElasticEntity<TKey>;
    }
}