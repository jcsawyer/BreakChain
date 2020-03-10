using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BreakChain.Models.Matches
{
    public class CompetitorStats
    {
        [Required]
        public string CompetitorId { get; set; }
        
        [Required]
        public int Fouls { get; set; }

        [Required]
        public int TrickShots { get; set; }
        
        [Required]
        public int CalledTrickShots { get; set; }
    }
}
