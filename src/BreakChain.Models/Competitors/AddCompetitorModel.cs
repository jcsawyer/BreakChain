using System.ComponentModel.DataAnnotations;

namespace BreakChain.Models.Competitors
{
    public class AddCompetitorModel
    {
        [Required]
        public string Name { get; set; }
    }
}
