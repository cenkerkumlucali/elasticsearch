using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Const;
using Business.ElasticSearchOptions.Abstract;
using Entity.Concrete.RealEstateAds;
using Nest;

namespace Business.Concrete
{
    public class RealEstateAdsManager : IRealEstateAdsService
    {
        private IElasticSearchService _elasticSearchService;
        public RealEstateAdsManager(IElasticSearchService elasticSearchService)
        {
            _elasticSearchService = elasticSearchService;
        }
        public async Task<RealEstateAds[]> GetBySearchText(string searchText, int skipItemCount = 0, int maxItemCount = 25)
        {
            var searchResultData = await _elasticSearchService.SimpleSearchAsync<RealEstateAds, int>
                (ElasticSearchIndex.RealEstateAdsIndexName, SearchQuery(searchText));

            var result = from resultData in searchResultData.Documents
                         select new RealEstateAds
                         {
                             property = resultData.property,
                         };
            return await Task.FromResult(result.ToArray());
        }
        private SearchDescriptor<RealEstateAds> SearchQuery(string searchText)
        {
            var searchJsonQuery = new Nest.SearchDescriptor<RealEstateAds>()
                .Query(q => q
                    .MultiMatch(m =>
                        m.Fields(f => 
                            f.Field(ff => ff.property.name, 1.0)
                               .Field(ff => ff.property.market,2.0)
                                  .Field(ff=>ff.property.city,1.0)
                                      .Field(ff=>ff.property.formerName,1.0)
                                          .Field(ff=>ff.property.streetAddress,1.0))
                                              .Query(searchText)
                                                  .Type(TextQueryType.BoolPrefix)
                    )
                );
            return searchJsonQuery;
        }
    }
}
