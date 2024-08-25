using Backend.Dtos;
using Backend.Models;

namespace Backend.Helpers
{
	public static class MemoryNoteExtensions
	{
		public static MemoryNote ToMemoryNoteFromCreateDto(this MemoryNoteCreateDto memoryNoteCreateDto)
		{
			return new MemoryNote
			{
				Name = memoryNoteCreateDto.Name ?? "",
				Description = memoryNoteCreateDto.Description,
				Priority = memoryNoteCreateDto.Priority,
				ListId = memoryNoteCreateDto.ListId,
			};
		}

		public static MemoryNoteReturnDto ToReturnDto(this MemoryNote memoryNote)
		{
			return new MemoryNoteReturnDto
			{
				Id = memoryNote.Id,
				Name = memoryNote.Name,
				Description = memoryNote.Description,
				Priority = memoryNote.Priority,
				DateTime = memoryNote.DateTime,
				ListId = memoryNote.ListId,
			};
		}

		public static List<MemoryNoteReturnDto> ToListOfMemoryNotes(this ICollection<MemoryNote> memoryNotes)
		{
			return memoryNotes.Select(memoryNotes => memoryNotes.ToReturnDto()).ToList();
		}
	}
}
