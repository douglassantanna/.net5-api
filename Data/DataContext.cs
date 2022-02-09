using apiRestDotNet5.Models;
using Microsoft.EntityFrameworkCore;

namespace apiRestDotNet5.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> opt) : base(opt)
        {

        }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
    }
}