using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BreakChain.Data;
using BreakChain.Data.Entities;
using BreakChain.Models.Competitors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BreakChain.Api.Controllers
{
    [ApiController]
    [Route("")]
    public class DefaultController : ControllerBase
    {
        private readonly ILogger<DefaultController> _logger;
        private readonly BreakChainDbContext _db;

        public DefaultController(
            ILogger<DefaultController> logger,
            BreakChainDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet("Leaderboard")]
        public async Task<IActionResult> Leaderboard()
            => Ok(await _db.Comptetitors.OrderByDescending(x => x.Wallet).ToListAsync());

        [HttpPost("AddCompetitor")]
        public async Task<IActionResult> AddCompetitor(AddCompetitorModel addCompetitorModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newCompetitor = new Competitor() { Name = addCompetitorModel.Name };

            await _db.Comptetitors.AddAsync(newCompetitor);
            await _db.SaveChangesAsync();

            return Ok(newCompetitor);
        }
    }
}
