using Backend.Dtos;
using Backend.Helpers;
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
		public async Task<ICollection<MemoryNote>> GetMemoryNotesAsync(MemoryNoteQuery query)
		{
			var notes = _context.MemoryNotes.AsQueryable();

			if (query.ListId != null)
			{
				notes = notes.Where( n => n.ListId == query.ListId);
			}

			switch (query.SortBy)
			{
				case "priorityAsc":
					notes = notes.OrderBy(n => n.Priority);
					break;

				case "priorityDesc":
					notes = notes.OrderByDescending(n => n.Priority);
					break;

				case "dateAsc":
					notes = notes.OrderBy(n => n.DateTime);
					break;

				case "dateDesc":
					notes = notes.OrderByDescending(n => n.DateTime);
					break;

				default:
					notes = notes.OrderBy(n => n.Id);
					break;
			}

			return await notes.ToListAsync();
		}

		public async Task<MemoryNote> CreateMemoryNoteAsync(MemoryNoteCreateDto memoryNoteCreateDto)
		{
			var check = await _context.Lists.FindAsync(memoryNoteCreateDto.ListId);

			if (check == null)
				return null;

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
