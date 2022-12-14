using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VotingAPI.Models;

namespace VotingAPI.Context
{
    public class VoteDBContext : DbContext
    {

        public VoteDBContext(DbContextOptions<VoteDBContext> options) : base(options)
        {

        }
        public DbSet<Candidates> Candidates { get; set; }
        public DbSet<CandidateCounts> Votes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidates>().ToTable("Candidates");
            modelBuilder.Entity<CandidateCounts>().ToTable("Votes");
        }
    }
}
