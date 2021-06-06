using System;
using System.Threading.Tasks;
using Business.ElasticSearchOptions.Abstract;
using Entity.ElasticEntity.Concrete;
using Nest;

namespace Business.ElasticSearchOptions.Concrete
{
    public class ElasticSearchManager:IElasticSearchService
    {
        public IElasticClient ElasticSearchClient { get;}
        private readonly IElasticSearchConfigration _elasticSearchConfigration;
        public ElasticSearchManager(IElasticSearchConfigration elasticSearchConfigration)
        {
            _elasticSearchConfigration = elasticSearchConfigration;
            ElasticSearchClient = GetClient();
        }
        private ElasticClient GetClient()
        {
            var connect = _elasticSearchConfigration.ConnectionString;
            var connectionString = new ConnectionSettings(new Uri(connect));
               
            if (!string.IsNullOrEmpty(_elasticSearchConfigration.AuthUserName) && !string.IsNullOrEmpty(_elasticSearchConfigration.AuthPassWord))
                connectionString.BasicAuthentication(_elasticSearchConfigration.AuthUserName, _elasticSearchConfigration.AuthPassWord);

            return new ElasticClient(connectionString);
        }

        public async Task<ISearchResponse<T>> SimpleSearchAsync<T, TKey>(string indexName, SearchDescriptor<T> query) where T : ElasticEntity<TKey>
        {
            query.Index(indexName);
            var response = await ElasticSearchClient.SearchAsync<T>(query);
            return response;
        }
       
    }
}