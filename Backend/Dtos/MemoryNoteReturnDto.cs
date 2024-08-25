using System.ComponentModel.DataAnnotations;

namespace Backend.Dtos
{
	public class MemoryNoteReturnDto
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string Description { get; set; }
		public int Priority { get; set; }
		public DateTime DateTime { get; set; }
		public int ListId { get; set; }
	}
}
