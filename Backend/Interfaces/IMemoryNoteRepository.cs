using Backend.Dtos;
using Backend.Helpers;
using Backend.Models;

namespace Backend.Interfaces
{
	public interface IMemoryNoteRepository
	{
		Task<ICollection<MemoryNote>> GetMemoryNotesAsync(MemoryNoteQuery query);
		Task<MemoryNote> GetMemoryNoteByIdAsync(int id);
		Task<MemoryNote> CreateMemoryNoteAsync(MemoryNoteCreateDto memoryNoteCreateDto);
		Task<MemoryNote> UpdateMemoryNoteAsync(int id, MemoryNoteUpdateDto updateMemoryNote);
		Task<MemoryNote> DeleteMemoryNoteAsync(int id);
	}
}
