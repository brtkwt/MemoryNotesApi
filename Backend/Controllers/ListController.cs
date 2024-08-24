﻿using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
			return Ok(allLists);
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetList(int id)
		{
			var list = await _listRepository.GetListByIdAsync(id);

			if (list == null)
				return NotFound();
			return Ok(list);
		}

		[HttpPost]
		public async Task<IActionResult> CreateList(string name)
		{
			List list1 = new List();
			list1.Name = name;

			var createdList = await _listRepository.CreateListAsync(list1);

			return Ok(createdList);
		}
	}
}
