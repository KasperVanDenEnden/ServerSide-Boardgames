﻿using Domain;
using Domain.Many_To_Many;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        // Tables from domain classes
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Gamenight> Gamenights { get; set; } = null!;
        public DbSet<Boardgame> Boardgames { get; set; } = null!;
        public DbSet<GamenightBoardgame> GamenightBoardgames { get; set; } = null!;
        public DbSet<Participating> Participatings { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GamenightBoardgame>()
                .HasKey(gb => new { gb.GamenightId, gb.BoardgameId });

            modelBuilder.Entity<Participating>()
                .HasKey(p => new { p.UserId, p.GamenightId });

            modelBuilder.Entity<Participating>()
                .HasOne(p => p.User)
                .WithMany(u => u.ParticipatingGamenights)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<Participating>()
                .HasOne(p => p.Gamenight)
                .WithMany(g => g.Participants)
                .HasForeignKey(p => p.GamenightId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Gamenight>()
                .HasOne(g => g.Host)
                .WithMany(u => u.HostedGamenights)
                .HasForeignKey(g => g.HostId);
        }
    }
}
