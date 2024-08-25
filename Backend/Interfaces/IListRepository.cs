using Backend.Models;

namespace Backend.Interfaces
{
	public interface IListRepository
	{
		Task<ICollection<List>> GetListsAsync();
		Task<List> GetListByIdAsync(int id);
		Task<List> CreateListAsync(List newList);
		Task<List> UpdateListAsync(int id, string newName);
		Task<List> DeleteListAsync(int id);
	}
}
