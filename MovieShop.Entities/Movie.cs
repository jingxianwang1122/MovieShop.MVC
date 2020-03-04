﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Entities
{
    [Table("Movie")]
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(256)]
        public string Title { get; set; }
        public string Overview { get; set; }
        [StringLength(512)]
        public string Tagline { get; set; }
        public decimal? Budget { get; set; }
        public decimal? Revenue { get; set; }
        [StringLength(2084)]
        public string ImdbUrl { get; set; }
        [StringLength(2084)]
        public string TmdbUrl { get; set; }
        [StringLength(2084)]
        public string PosterUrl { get; set; }
        [StringLength(2084)]
        public string BackdropUrl { get; set; }
        [StringLength(64)]
        public string OriginalLanguage { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? ReleaseDate { get; set; }
        public int? RunTime { get; set; }
        public decimal? Price { get; set; }
        [Column(TypeName = "datetime2")]

        [NotMapped] // dont wannat create an actual column in the table. The rating is changing.
        public decimal? Rating { get; set; }
        public DateTime? CreatedDate { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }

        public virtual ICollection<Favorite> Favorites { get; set; }

        public virtual ICollection<MovieCast> MovieCasts { get; set; }

        public virtual ICollection<MovieCrew> MovieCrews { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Genre> Genres { get; set; }


    }
}
