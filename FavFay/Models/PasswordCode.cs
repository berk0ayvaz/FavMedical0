using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FavFay.Models
{
    public class PasswordCode
    {
        public int Id { get; set; }
        public kullanici Kullanici { get; set; }
        public int UserId { get; set; }

        [StringLength(6)]
        public string Code { get; set; }
    }
}
