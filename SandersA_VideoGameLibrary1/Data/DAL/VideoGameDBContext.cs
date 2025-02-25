using Microsoft.EntityFrameworkCore;
using SandersA_VideoGameLibrary1.Data.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace SandersA_VideoGameLibrary.Data.DAL
{
    public class VideoGameDBContext : DbContext
    {

        public VideoGameDBContext(DbContextOptions<VideoGameDBContext> options)
            : base(options)
        {
        }

        public DbSet<VideoGame> VideoGames { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VideoGame>().HasKey(v => v.Id);
            modelBuilder.Entity<VideoGame>().ToTable("Video Games");
        }
    }
}
