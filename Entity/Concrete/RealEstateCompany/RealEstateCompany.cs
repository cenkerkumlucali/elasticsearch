using Entity.ElasticEntity.Concrete;

namespace Entity.Concrete.RealEstateCompany
{
    public class RealEstateCompany : ElasticEntity<int>
    {
        public Mgmt mgmt { get; set; }
    }
}