using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos
{
	public class MemoryNoteCreateDto
	{
		public string? Name { get; set; }

		[Required]
		public string Description { get; set; }

		[Required, Range(1, 3)]
		public int Priority { get; set; }

		[Required, Range(1, int.MaxValue)]
		public int ListId { get; set; }
	}
}
