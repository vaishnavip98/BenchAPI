using Bench.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BenchAPI.Controllers
{
	[ApiController]
	[Route("api/[Controller]")]
	public class PartnerController : Controller
	{
		private readonly BenchDbContext _benchDbContext;

		public PartnerController(BenchDbContext benchDbContext)
		{
			_benchDbContext = benchDbContext;
		}
		[HttpGet]
		public async Task<IActionResult> GetAllPartner()
		{
			var partner = await _benchDbContext.Partners.ToListAsync();
			return Ok(partner);
		}

        [HttpGet("{benchId}")]
        //[Route("{benchId:Guid}")]
        public async Task<IActionResult> GetPartner([FromRoute] Guid benchId)
        {
            if (_benchDbContext.Benchs == null)
            {
                return NotFound();
            }
            var bench = await _benchDbContext.Partners.FirstOrDefaultAsync(x => x.PartnerId == benchId);

            if (bench == null)
            {
                return NotFound();
            }
            return Ok(bench);

        }
    }
}
