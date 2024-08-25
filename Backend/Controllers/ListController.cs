using Backend.Dtos;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend.Helpers;

namespace Backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ListController : ControllerBase
	{
		private readonly IListRepository _listRepository;

		public ListController(IListRepository listRepository)
        {
			this._listRepository = listRepository;
		}

        [HttpGet]
		public async Task<IActionResult> GetAllLists()
		{
			var allLists = await _listRepository.GetListsAsync();

			if(allLists == null) 
				return NotFound();

			return Ok(allLists.ToListofListDtos());
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetList(int id)
		{
			var list = await _listRepository.GetListByIdAsync(id);

			if (list == null)
				return NotFound();
			return Ok(list.ToListDto());
		}

		[HttpPost]
		public async Task<IActionResult> CreateList([FromBody] string name)
		{
			var createdList = await _listRepository.CreateListAsync(name);

			return Ok(createdList);
		}

		[HttpPatch("{id:int}")]
		public async Task<IActionResult> UpdateListName(int id, [FromBody] string newName)
		{
			var updatedList = await _listRepository.UpdateListAsync(id, newName);

			if (updatedList == null)
				return NotFound();

			return Ok(updatedList);
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteList(int id)
		{
			var existingList = await _listRepository.DeleteListAsync(id);

			if( existingList == null)
				return NotFound();

			return NoContent();
		}
	}
}
