using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BreakChain.Data.Entities
{
    [Table("Competitors")]
    public class Competitor : Entity
    {
        public string Name { get; set; }
        public long Wallet { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }

        public virtual ICollection<MatchCompetitor> Matches { get; set; }
        public virtual ICollection<Match> MatchWins { get; set; }
        public virtual ICollection<Match> MatchLosses { get; set; }

        public Competitor() : base()
        {

        }
    }
}
