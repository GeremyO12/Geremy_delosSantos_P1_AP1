using Geremy_delosSantos_P1_AP1.Models;
using Microsoft.EntityFrameworkCore;

namespace Geremy_delosSantos_P1_AP1.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<Aporte> Aporte { get; set; }
    }
}
