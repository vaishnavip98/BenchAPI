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
	}
}
