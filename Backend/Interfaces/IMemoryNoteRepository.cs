using Backend.Dtos;
using Backend.Models;

namespace Backend.Interfaces
{
	public interface IMemoryNoteRepository
	{
		Task<ICollection<MemoryNote>> GetMemoryNotesForListIdAsync(int id);
		Task<MemoryNote> GetMemoryNoteByIdAsync(int id);
		Task<MemoryNote> CreateMemoryNoteAsync(MemoryNoteCreateDto memoryNoteCreateDto);
		Task<MemoryNote> UpdateMemoryNoteAsync(int id, MemoryNoteUpdateDto updateMemoryNote);
		Task<MemoryNote> DeleteMemoryNoteAsync(int id);
	}
}
