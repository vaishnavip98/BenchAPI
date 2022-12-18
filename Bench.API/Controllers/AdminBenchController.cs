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

        [HttpGet("{benchId}")]
        //[Route("{benchId:Guid}")]
        public async Task<IActionResult> GetBench([FromRoute] Guid benchId)
        {
            if(_benchDbContext.Benchs==null)
            {
                return NotFound();
            }
           var bench = await  _benchDbContext.Benchs.FirstOrDefaultAsync(x => x.BenchId == benchId);
            if(bench == null)
            {
                return NotFound();
            }
            return Ok(bench);

        }
        [HttpPut]
        [Route("{benchId:Guid}")]

        public async Task<IActionResult> UpdateBench([FromRoute] Guid benchId, BenchResource updateBenchRequest) 
        {
            var bench = await _benchDbContext.Benchs.FindAsync(benchId);
            if(bench == null)
            {
                return NotFound();
            }
            bench.PartnerId = updateBenchRequest.PartnerId;
            bench.NoOfResource = updateBenchRequest.NoOfResource;
            bench.SkillSet = updateBenchRequest.SkillSet;
            bench.YearsOfExperince = updateBenchRequest.YearsOfExperince;
            bench.RatePerHrUSD = updateBenchRequest.RatePerHrUSD;

            await _benchDbContext.SaveChangesAsync();
            return Ok(bench);
        }


        [HttpDelete]
        [Route("{benchId:Guid}")]
        public async Task<IActionResult> DeleteBench([FromRoute] Guid benchId)
        {
            if (_benchDbContext.Benchs == null)
            {
                return NotFound();
            }
            var bench = await _benchDbContext.Benchs.FirstAsync(benchId);

            if(bench == null )
            {
                return NotFound();
            }
            _benchDbContext.Benchs.Remove(bench);
            await _benchDbContext.SaveChangesAsync();

            return Ok();
        }

    }  
}
