using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavFay.Models
{
    public class Context:DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<kullanici> kullanıcilars { get; set; }

        public DbSet<Employee> employees { get; set; }

        public DbSet<PasswordCode> PasswordCodes { get; set; }

 
    }
}
