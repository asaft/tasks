using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using usertasks.Models;

namespace usertasks
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        public override int SaveChanges()
        {
            var entities = ChangeTracker
                            .Entries()
                            .Where(x => x.Entity is BaseEntity && (x.State == EntityState.Modified || x.State == EntityState.Added))
                            .Select(x => x.Entity)
                            .Cast<BaseEntity>();

            DateTime now = DateTime.Now;
            foreach (var entity in entities)
            {
                entity.UpdatedAt = now;
            }
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                FirstName = "John",
                LastName = "Smith",
                UserName = "jsmith",
                Password = "123456"
            }, new User
            {
                Id = 2,
                FirstName = "Eve",
                LastName = "Jackson",
                UserName = "ejackson",
                Password = "654321"
            }
            );
    
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}