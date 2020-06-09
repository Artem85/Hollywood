using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hollywood.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public int DirectorId { get; set; }
        public Director Director { get; set; }

        public ICollection<ActorMovie> ActorMovies { get; set; }
    }
}
