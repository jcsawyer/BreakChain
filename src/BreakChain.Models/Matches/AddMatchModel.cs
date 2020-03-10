using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BreakChain.Models.Matches
{
    public class AddMatchModel
    {
        [Required]
        public long Stake { get; set; }

        [Required]
        public CompetitorStats WinnerCompetitor { get; set; }

        [Required]
        public CompetitorStats LosingCompetitor { get; set; }
    }
}
