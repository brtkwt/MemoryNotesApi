using Backend.Models;

namespace Backend.Interfaces
{
	public interface IListRepository
	{
		Task<ICollection<List>> GetListsAsync();
		Task<List> GetListByIdAsync(int id);
		Task<List> CreateListAsync(string name);
		Task<List> UpdateListAsync(int id, string newName);
		Task<List> DeleteListAsync(int id);
	}
}
