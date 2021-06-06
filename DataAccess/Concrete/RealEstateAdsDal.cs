using System.IO;
using System.Text.Json;
using DataAccess.Abstract;
using Entity.Concrete.RealEstateAds;

namespace DataAccess.Concrete
{
    public class RealEstateAdsDal:IRealEstateAdsDal
    {
        public Property[] GetAll()
        {
            string fileName = "properties.json";
            string jsonString = File.ReadAllText(fileName);
            Property[] realEstateAds = JsonSerializer.Deserialize<Property[]>(jsonString);
            return realEstateAds;
        }
    }
}