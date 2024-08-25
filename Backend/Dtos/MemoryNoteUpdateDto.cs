using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos
{
	public class MemoryNoteUpdateDto
	{
		public string? Name { get; set; }

		[Required]
		public string Description { get; set; }

		[Required, Range(1, 3)]
		public int Priority { get; set; }
	}
}
