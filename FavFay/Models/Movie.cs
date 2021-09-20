using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FavFay.Models
{
    public class Movie
    {
        [Key]
        public int movieId { get; set; } //id

      

        public string type { get; set; } //kitap vs
        public string Title { get; set; }
        public string Description { get; set; } //tür(korku gerilim vs)
        public string Director { get; set; }
        public string[] Players { get; set; }

        public string mainContent { get; set; }

        public string ImgURL { get; set; }
    }
}
