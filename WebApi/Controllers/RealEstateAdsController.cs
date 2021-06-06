using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Business.Abstract;
using Entity.Concrete.RealEstateAds;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealEstateAdsController : ControllerBase
    {
        private IRealEstateAdsService _realEstateAdsService;

        public RealEstateAdsController(IRealEstateAdsService realEstateAdsService)
        {
            _realEstateAdsService = realEstateAdsService;
        }

        [HttpGet("getRealEstateAdsBySearchText")]
        public async Task<RealEstateAds[]> GetRealEstateAdsBySearchText(string searchText)
        {
            return await Task.FromResult(_realEstateAdsService.GetBySearchText(searchText).Result);
        }
    }
}
