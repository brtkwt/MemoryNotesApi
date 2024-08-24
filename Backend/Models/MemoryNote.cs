using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
	public class MemoryNote
	{
		[Required]
		public int Id { get; set; }
		public string? Name { get; set; }

		[Required]
		public string Description { get; set; } = string.Empty;

		[Required, Range(1,3)]
		public int Priority { get; set; }

		[Required]
		public DateTime DateTime { get; set; } = DateTime.Now;

		public int ListId { get; set; }
		public List List { get; set; }
	}
}
