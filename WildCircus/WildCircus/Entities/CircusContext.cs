using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace WildCircus
{
    public class CircusContext : DbContext
    {
        public virtual DbSet<Performer> Performers { get; set; }
        public virtual DbSet<PerformerShow> PerformerShows { get; set; }
        public virtual DbSet<Show> Shows { get; set; }
        public virtual DbSet<ShowOrder> ShowOrders { get; set; }
        public virtual DbSet<TicketOrder> TicketOrders { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LOCALHOST\SQLEXPRESS;Database=WildCircus;Integrated Security=True;MultipleActiveResultSets=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PerformerShow>()
                .HasKey(ps => new { ps.PerformerId, ps.ShowId });
            modelBuilder.Entity<PerformerShow>()
                .HasOne(ps => ps.Performer)
                .WithMany(p => p.ManyPerformerShow)
                .HasForeignKey(ps => ps.PerformerId);
            modelBuilder.Entity<PerformerShow>()
                .HasOne(ps => ps.Show)
                .WithMany(s => s.ManyPerformerShow)
                .HasForeignKey(ps => ps.ShowId);

            modelBuilder.Entity<ShowOrder>()
                .HasKey(so => new { so.ShowId, so.TicketOrderId });
            modelBuilder.Entity<ShowOrder>()
                .HasOne(so => so.Show)
                .WithMany(o => o.ManyShowOrder)
                .HasForeignKey(so=>so.ShowId);
            modelBuilder.Entity<ShowOrder>()
                .HasOne(so => so.TicketOrder)
                .WithMany(s => s.ManyShowOrder)
                .HasForeignKey(so => so.TicketOrderId);
        }
    }
}
