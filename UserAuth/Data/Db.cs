using Microsoft.EntityFrameworkCore;
using System;
using UserAuth.Models.Entities;

namespace UserAuth.Data
{
    public class Db : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Subscriptions> Subscriptions { get; set; }
        public DbSet<UserSubscriptions> UserSubscriptions { get; set; }
        public DbSet<Models.Responses.UserSubscriptionsResponse.GetUserSubscriptionResponse> GetUserSubscriptionResponse { get; set; }

        public Db(DbContextOptions<Db> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure stored procedures if needed
            modelBuilder.Entity<User>().HasKey(e => e.Id);
            modelBuilder.Entity<Subscriptions>().HasKey(e => e.Id);
            modelBuilder.Entity<UserSubscriptions>().HasKey(e => e.Id);
        }
    }
}
