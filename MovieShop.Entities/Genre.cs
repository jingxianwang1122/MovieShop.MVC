using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Entities
{
    [Table ("Genre")]
    public class Genre
    {
        public int ID { get; set; }

        [Required]
        [StringLength(64)]
        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }

        /*
        public void TestMethod()
        {
            var test= new List<>  //generic are the concept introduced in c# version 2, the advantage is we can write template code with placeholders, provide type safety.
        }
        */
    }  
}
