using Backend.Dtos;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data.Repositories
{
	public class MemoryNoteRepository : IMemoryNoteRepository
	{
		private readonly DataContext _context;

		public MemoryNoteRepository(DataContext context)
        {
			_context = context;
		}

		public async Task<MemoryNote> GetMemoryNoteByIdAsync(int id)
		{
			return await _context.MemoryNotes.FirstOrDefaultAsync(l => l.Id == id);
		}

		// do zrobienia query
		//public async Task<ICollection<MemoryNote>> GetMemoryNotesForListIdAsync()
		//{

		//}

		public async Task<MemoryNote> CreateMemoryNoteAsync(MemoryNoteCreateDto memoryNoteCreateDto)
		{
			MemoryNote newMemoryNote = new MemoryNote()
			{
				Name = memoryNoteCreateDto.Name,
				Description = memoryNoteCreateDto.Description,
				Priority = memoryNoteCreateDto.Priority,
				ListId = memoryNoteCreateDto.ListId,
			};

			await _context.MemoryNotes.AddAsync(newMemoryNote);
			await _context.SaveChangesAsync();

			return newMemoryNote;
		}

		public async Task<MemoryNote> UpdateMemoryNoteAsync(int id, MemoryNoteUpdateDto updateMemoryNote)
		{
			var existingMemoryNote = await _context.MemoryNotes.FindAsync(id);

			if (existingMemoryNote == null)
				return null;

			existingMemoryNote.Name = updateMemoryNote.Name ?? "";
			existingMemoryNote.Description = updateMemoryNote.Description;
			existingMemoryNote.Priority = updateMemoryNote.Priority;

			_context.Update(existingMemoryNote);
			await _context.SaveChangesAsync();

			return existingMemoryNote;
		}

		public async Task<MemoryNote> DeleteMemoryNoteAsync(int id)
		{
			var existingMemoryNote = await _context.MemoryNotes.FindAsync(id);

			if (existingMemoryNote == null)
				return null;

			_context.MemoryNotes.Remove(existingMemoryNote);
			await _context.SaveChangesAsync();

			return existingMemoryNote;
		}

	}
}
