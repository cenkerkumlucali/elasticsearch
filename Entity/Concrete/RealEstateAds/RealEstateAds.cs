using Entity.ElasticEntity.Concrete;

namespace Entity.Concrete.RealEstateAds
{

    public class RealEstateAds:ElasticEntity<int>
    {
        public Property property { get; set; }
    }
}