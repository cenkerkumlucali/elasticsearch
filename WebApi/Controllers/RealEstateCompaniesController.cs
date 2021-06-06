using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Business.Abstract;
using Entity.Concrete.RealEstateCompany;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealEstateCompaniesController : ControllerBase
    {
        private IRealEstateCompanyService _realEstateCompanyService;

        public RealEstateCompaniesController(IRealEstateCompanyService realEstateCompanyService)
        {
            _realEstateCompanyService = realEstateCompanyService;
        }
        [HttpGet("getRealEstateCompanyBySearchText")]
        public async Task<RealEstateCompany[]> GetRealEstateAdsBySearchText(string searchText)
        {
            return await Task.FromResult(_realEstateCompanyService.GetBySearchText(searchText).Result);
        }

    }
}
