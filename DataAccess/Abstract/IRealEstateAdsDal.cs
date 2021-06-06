using Entity.Concrete.RealEstateAds;

namespace DataAccess.Abstract
{
    public interface IRealEstateAdsDal
    {
        Property[] GetAll();
    }
}