using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Entities
{
    [Table("Cast")]
    public class Cast
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter cast name")]
        [StringLength(128, ErrorMessage ="The maximum length should be 256")]
        public string Name { get; set; }

        public string Gender { get; set; }

        [StringLength(2084)]
        [Url]
        public string TmdbUrl { get; set; }

        [StringLength(2084)]
        [Url()]
        public string ProfilePath { get; set; }

        public ICollection<MovieCast> MovieCasts { get; set; }
    }
}
