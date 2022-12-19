using Bench.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BenchAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]

	public class SearchController : Controller
	{
		private readonly BenchDbContext _benchDbContext;
		public SearchController(BenchDbContext benchDbContext)
		{
			_benchDbContext = benchDbContext;
		}
		[HttpGet("{value}")]

		public async Task<IActionResult> GetAllBenchBySearchValue(string value)
		{
			var benchs = await _benchDbContext.Benchs.Where(x => (x.SkillSet.Contains(value)|| x.YearsOfExperince.Contains(value)|| x.RatePerHrUSD.ToString().Contains(value)|| x.NoOfResource.ToString().Contains(value))).ToListAsync();
			return Ok(benchs);

		}
	}
}
