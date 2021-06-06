using Entity.Concrete.RealEstateCompany;

namespace DataAccess.Abstract
{
    public interface IRealEstateCompanyDal
    {
        Mgmt[] GetAll();
    }
}