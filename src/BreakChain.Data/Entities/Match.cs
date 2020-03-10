using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BreakChain.Data.Entities
{
    [Table("Matches")]
    public class Match : Entity
    {
        public long Stake { get; set; }
        public virtual ICollection<MatchCompetitor> Competitors { get; set; }

        public string WinningCompetitorId { get; set; }
        public virtual Competitor WinningCompetitor { get; set; }

        public string LosingCompetitorId { get; set; }
        public virtual Competitor LosingCompetitor { get; set; }

        public long CurrentFoulPot { get; set; }

        public Match() : base()
        {

        }
    }
}
