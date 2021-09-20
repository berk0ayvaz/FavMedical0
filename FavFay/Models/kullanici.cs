using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FavFay.Models
{
    public class kullanici
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string UserName{ get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        
   

    }
}
