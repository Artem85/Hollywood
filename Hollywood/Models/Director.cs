using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hollywood.Models
{
    public class Director
    {
        public int Id { get; set; }

        [Required]
        [Column("FullName", TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        public Movie Movie { get; set; }
    }
}
