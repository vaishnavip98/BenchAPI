using Bench.API.Data;
using BenchAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BenchAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AdminBenchController : Controller
    {
        private readonly BenchDbContext _benchDbContext;
        public AdminBenchController(BenchDbContext benchDbContext)
        {
            _benchDbContext = benchDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBench()
        {
            var benchs = await _benchDbContext.Benchs.ToListAsync();
            return Ok(benchs);

        }

        [HttpPost]
        public async Task<IActionResult> AddBench([FromBody] BenchResource benchRequest)
        {
            benchRequest.BenchId = Guid.NewGuid();
            await _benchDbContext.Benchs.AddAsync(benchRequest);
            await _benchDbContext.SaveChangesAsync();
            return Ok(benchRequest);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetBench([FromRoute] Guid Benchid)
        {
           var bench = await  _benchDbContext.Benchs.FirstOrDefaultAsync(x => x.BenchId == Benchid);
            if(bench == null)
            {
                return NotFound();
            }
            return Ok(bench);

        }

    }  
}
