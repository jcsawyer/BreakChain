using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BreakChain.Data;
using BreakChain.Data.Entities;
using BreakChain.Models.Competitors;
using BreakChain.Models.Matches;
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
            => Ok(await _db.Competitors.OrderByDescending(x => x.Wallet).ToListAsync());

        [HttpGet("FoulPot")]
        public async Task<IActionResult> FoulPot()
            => Ok((await _db.Matches.OrderByDescending(x => x.Timestamp).FirstOrDefaultAsync())?.CurrentFoulPot);

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

            return Ok(await _db.Competitors
                .Include(x => x.MatchWins.OrderByDescending(x => x.Timestamp).Take(5))
                .Include(x => x.MatchLosses.OrderByDescending(x => x.Timestamp).Take(5))
                .FirstOrDefaultAsync(x => x.Id == competitorId));
        }

        [HttpGet("Competitor/{competitorId}/Matches/{page?}/{size?}")]
        public async Task<IActionResult> CompetitorMatches(string competitorId, int page = 1, int size = 10)
        {
            if (string.IsNullOrEmpty(competitorId))
                return BadRequest($"{nameof(competitorId)} cannot be empty");

            if (page < 1) page = 1;
            if (size < 1) size = 10;

            return Ok(await _db.Matches
                .Include(x => x.WinningCompetitor)
                .Include(x => x.LosingCompetitor)
                .OrderByDescending(x => x.Timestamp)
                .Skip((page - 1) * size)
                .Take(size)
                .Where(x => x.WinningCompetitorId == competitorId || x.LosingCompetitorId == competitorId)
                .ToListAsync());
        }

        [HttpPost("AddMatch")]
        public async Task<IActionResult> AddMatch(AddMatchModel addMatchModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var winnerCompetitor = await _db.Competitors.FindAsync(addMatchModel.WinnerCompetitor.CompetitorId);
            if (winnerCompetitor == null)
                return BadRequest("Winner competitor does not exist");
            var losingCompetitor = await _db.Competitors.FindAsync(addMatchModel.LosingCompetitor.CompetitorId);
            if (losingCompetitor == null)
                return BadRequest("Losing competitor does not exist");

            winnerCompetitor.Wins += 1;
            winnerCompetitor.Wallet += addMatchModel.WinnerCompetitor.TrickShots + (addMatchModel.WinnerCompetitor.CalledTrickShots * 5) - addMatchModel.WinnerCompetitor.Fouls;
            losingCompetitor.Losses += 1;
            losingCompetitor.Wallet += addMatchModel.LosingCompetitor.TrickShots + (addMatchModel.LosingCompetitor.CalledTrickShots * 5) - addMatchModel.LosingCompetitor.Fouls;

            var currentFoulPot = (await _db.Matches.OrderByDescending(x => x.Timestamp).FirstOrDefaultAsync())?.Stake;

            var newMatch = new Match()
            {
                Stake = addMatchModel.Stake,
                CurrentFoulPot = addMatchModel.LosingCompetitor.Fouls + addMatchModel.WinnerCompetitor.Fouls
            };

            _db.Competitors.Update(winnerCompetitor);
            _db.Competitors.Update(losingCompetitor);
            await _db.AddAsync(newMatch);
            await _db.SaveChangesAsync();

            var winnerMatchCompetitor = new MatchCompetitor() { CompetitorId = addMatchModel.WinnerCompetitor.CompetitorId, MatchId = newMatch.Id };
            var loserMatchCompetitor = new MatchCompetitor() { CompetitorId = addMatchModel.LosingCompetitor.CompetitorId, MatchId = newMatch.Id };

            await _db.AddRangeAsync(new { winnerMatchCompetitor, loserMatchCompetitor });
            await _db.SaveChangesAsync();

            return Ok(newMatch.Id);
        }

        [HttpPost("AddCompetitor")]
        public async Task<IActionResult> AddCompetitor(AddCompetitorModel addCompetitorModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newCompetitor = new Competitor() { Name = addCompetitorModel.Name };

            await _db.Competitors.AddAsync(newCompetitor);
            await _db.SaveChangesAsync();

            return Ok(newCompetitor);
        }
    }
}
