using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
	public class MemoryNote
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string Description { get; set; } = string.Empty;
		public int Priority { get; set; }
		public DateTime DateTime { get; set; } = DateTime.Now;
		public int ListId { get; set; }
		public List List { get; set; }
	}
}
