using System.ComponentModel.DataAnnotations.Schema;

namespace BreakChain.Data.Entities
{
    [Table("MatchCompetitors")]
    public class MatchCompetitor : Entity
    {
        public string CompetitorId { get; set; }
        public virtual Competitor Competitor { get; set; }
        public string MatchId { get; set; }
        public virtual Match Match { get; set; }

        public MatchCompetitor() : base() { }
    }
}
