namespace DAL
{
    using DAL.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AuctionContext : DbContext
    {
        
        public AuctionContext()
            : base("name=AuctionContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; }
        public DbSet<Lot> Lots { get; set; }
    }
}