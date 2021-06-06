using System.IO;
using System.Text.Json;
using DataAccess.Abstract;
using Entity.Concrete.RealEstateCompany;

namespace DataAccess.Concrete
{
    public class RealEstateCompanyDal:IRealEstateCompanyDal
    {
        public Mgmt[] GetAll()
        {
            string fileName = "mgmt.json";
            string jsonString = File.ReadAllText(fileName);
            Mgmt[] realEstateCompany= JsonSerializer.Deserialize<Mgmt[]>(jsonString);
            return realEstateCompany;
        }
    }
}