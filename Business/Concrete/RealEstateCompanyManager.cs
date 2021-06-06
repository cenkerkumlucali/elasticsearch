using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Const;
using Business.ElasticSearchOptions.Abstract;
using Entity.Concrete.RealEstateCompany;
using Nest;

namespace Business.Concrete
{
    public class RealEstateCompanyManager:IRealEstateCompanyService
    {
        private IElasticSearchService _elasticSearchService;
        public RealEstateCompanyManager(IElasticSearchService elasticSearchService)
        {
            _elasticSearchService = elasticSearchService;
        }
        public async Task<RealEstateCompany[]> GetBySearchText(string searchText, int skipItemCount = 0, int maxItemCount = 25)
        {
            var searchResultData = await _elasticSearchService.SimpleSearchAsync<RealEstateCompany, int>
                (ElasticSearchIndex.RealEstateCompanyIndexName, SearchQuery(searchText));

            var result = from opt in searchResultData.Documents
                select new RealEstateCompany
                {
                    mgmt = opt.mgmt
                };
            return await Task.FromResult(result.ToArray());
        }
        private SearchDescriptor<RealEstateCompany> SearchQuery(string searchText)
        {
            var searchJsonQuery = new Nest.SearchDescriptor<RealEstateCompany>()
                .Query(q => q
                    .MultiMatch(m => 
                        m.Fields(f => 
                                f.Field(ff => ff.mgmt.name)
                                    .Field(ff=>ff.mgmt.market)
                                        .Field(ff=>ff.mgmt.state))
                                            .Query(searchText)
                                                 .Type(TextQueryType.BoolPrefix)
                    )
                );
            return searchJsonQuery;
        }
    }
}