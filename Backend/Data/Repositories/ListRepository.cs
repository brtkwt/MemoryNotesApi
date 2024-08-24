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
			this._context = context;
		}

		public async Task<ICollection<List>> GetListsAsync()
		{
			return await _context.Lists.Include(l => l.ListNotes).ToListAsync();
		}

		public async Task<List> GetListByIdAsync(int id)
		{
			return await _context.Lists.Include(l => l.ListNotes).FirstOrDefaultAsync(l => l.Id == id);
		}


	}
}
