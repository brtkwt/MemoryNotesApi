using Backend.Models;

namespace Backend.Interfaces
{
	public interface IListRepository
	{
		Task<ICollection<List>> GetListsAsync();
		Task<List> GetListByIdAsync(int id);



	}
}
