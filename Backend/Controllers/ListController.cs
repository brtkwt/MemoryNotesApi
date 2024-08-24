using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ListController : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetAllLists()
		{
			return Ok();
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetList()
		{
			return Ok();
		}
	}
}
