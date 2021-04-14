using Microsoft.EntityFrameworkCore;
using Net50MoviesApp.Entity;

namespace Net50MoviesApp.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Crew> Crew { get; set; }
        public DbSet<Cast> Players { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=movies.db");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().Property(b => b.Title).IsRequired();
            modelBuilder.Entity<Movie>().Property(b => b.Description).HasMaxLength(500);

            modelBuilder.Entity<Genre>().Property(b => b.Name).IsRequired();
            modelBuilder.Entity<Genre>().Property(b => b.Name   ).HasMaxLength(50);

        }
    }

}
