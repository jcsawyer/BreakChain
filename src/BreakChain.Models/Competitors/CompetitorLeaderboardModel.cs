using BreakChain.Data.Entities;

namespace BreakChain.Models.Competitors
{
    public class CompetitorListModel
    {
        public string Name { get; set; }
        public long Wallet { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }

        public CompetitorListModel() { }

        public CompetitorListModel(Competitor competitor)
        {
            Name = competitor.Name;
            Wallet = competitor.Wallet;
            Wins = competitor.Wins;
            Losses = competitor.Losses;
        }
    }
}
