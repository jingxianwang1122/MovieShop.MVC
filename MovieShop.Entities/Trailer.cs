using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Entities
{
    [Table("Trailer")]
    public class Trailer
    {
        public int Id { get; set; }
        public int MovieId { get; set; } //FK

        [StringLength(2084)]
        public string TrailerUrl { get; set; }

        [StringLength(2084)]
        public string Name { get; set; }
        public Movie Movie { get; set; } //navigation property(use to join): movie object stores everything in the movie table. give more details about the movie(given trailer id, we can get more information about the FK(movie) table)
    }
}
