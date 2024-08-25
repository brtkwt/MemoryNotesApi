using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data.Repositories
{
	public class ListRepository : IListRepository
	{
		private readonly DataContext _context;

		public ListRepository(DataContext context)
        {
			_context = context;
		}

		public async Task<ICollection<List>> GetListsAsync()
		{
			return await _context.Lists.ToListAsync();
		}

		public async Task<List> GetListByIdAsync(int id)
		{
			return await _context.Lists.FirstOrDefaultAsync(l => l.Id == id);
		}

		public async Task<List> CreateListAsync(List newList)
		{
			await _context.Lists.AddAsync(newList);
			await _context.SaveChangesAsync();

			return newList;
		}

		public async Task<List> UpdateListAsync(int id, string newName)
		{
			var existingList = await _context.Lists.FindAsync(id);

			if (existingList == null)
				return null;

			existingList.Name = newName;

			_context.Update(existingList);
			await _context.SaveChangesAsync();

			return await _context.Lists.FirstOrDefaultAsync(l => l.Id == id);
		}

		public async Task<List> DeleteListAsync(int id)
		{
			var existingList = await _context.Lists.FindAsync(id);

			if(existingList == null)
				return null;

			_context.Lists.Remove(existingList);
			await _context.SaveChangesAsync();

			return existingList;
		}
	}
}
