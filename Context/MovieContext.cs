using Microsoft.EntityFrameworkCore;
using Sampleimdb.Models;

namespace Sampleimdb.Context
{
    public class MovieContext : DbContext
    {
        public MovieContext() : this(new DbContextOptions<MovieContext>())
        {

        }
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Actor> Actor { get; set; }
        public DbSet<Producer> Producer { get; set; }
        public DbSet<DocPkValue> DocPkValue { get; set; }
        public DbSet<Sample> Sample { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

        }
    }
}
