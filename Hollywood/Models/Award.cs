using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hollywood.Models
{
    public class Award
    {
        [Column(TypeName = "nvarchar(15)")]
        public AwardType Title { get; set; }

        [Required]
        [Column("Year", TypeName = "smallint")]
        public int DeliveryYear { get; set; }

        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }

    public enum AwardType
    {
        Oscar,
        GoldenGlobe,
        BAFTA
    }
}
