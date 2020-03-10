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

        [HttpGet("FoulPot")]
        public async Task<IActionResult> FoulPot()
            => Ok((await _db.Matches.OrderByDescending(x => x.Timestamp).FirstOrDefaultAsync()).CurrentFoulPot);

        [HttpGet("Matches/{page?}/{size?}")]
        public async Task<IActionResult> Matches(int page = 1, int size = 10)
        {
            if (page < 1) page = 1;
            if (size < 1) size = 10;

            return Ok(await _db.Matches
                .Skip((page - 1) * size)
                .Take(size)
                .Include(x => x.WinningCompetitor)
                .Include(x => x.LosingCompetitor)
                .ToListAsync());
        }

        [HttpGet("Competitor/{competitorId}")]
        public async Task<IActionResult> Competitor(string competitorId)
        {
            if (string.IsNullOrEmpty(competitorId))
                return BadRequest($"{nameof(competitorId)} cannot be empty");

            return Ok(await _db.Comptetitors
                .Include(x => x.MatchWins.Take(5))
                .Include(x => x.MatchLosses.Take(5))
                .FirstOrDefaultAsync(x => x.Id == competitorId));
        }


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
