using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
	public class List
	{
		[Required]
		public int Id { get; set; }

		[Required, MaxLength(20)]
		public string Name { get; set; } = string.Empty;

		public ICollection<MemoryNote> ListNotes { get; set; }
	}
}
