using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}

		public DbSet<List> Lists { get; set; }
		public DbSet<MemoryNote> MemoryNotes { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<MemoryNote>()
				.HasOne(m => m.List)
				.WithMany(l => l.ListNotes)
				.HasForeignKey(n => n.ListId);
		}
	}
}
