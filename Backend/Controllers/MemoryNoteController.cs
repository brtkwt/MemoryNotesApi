using Backend.Dtos;
using Backend.Helpers;
using Backend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MemoryNoteController : ControllerBase
	{
		private readonly IMemoryNoteRepository _memoryNoteRepository;

		public MemoryNoteController(IMemoryNoteRepository memoryNoteRepository)
        {
			_memoryNoteRepository = memoryNoteRepository;
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetMemoryNoteById(int id)
		{
			var memoryNote = await _memoryNoteRepository.GetMemoryNoteByIdAsync(id);

			if (memoryNote == null)
				return NotFound();
			return Ok(memoryNote.ToReturnDto());
		}

        [HttpGet("list/{id:int}")]
		public async Task<IActionResult> GetMemoryNotesForListId(int id)
		{
			var memoryNotes = await _memoryNoteRepository.GetMemoryNotesForListIdAsync(id);

			if (memoryNotes == null)
				return NotFound();

			return Ok(memoryNotes.ToListOfMemoryNoteDtos());
		}

		[HttpPost]
		public async Task<IActionResult> CreateMemoryNote([FromBody] MemoryNoteCreateDto memoryNoteCreateDto)
		{
			var createdMemoryNote = await _memoryNoteRepository.CreateMemoryNoteAsync(memoryNoteCreateDto);

			if (createdMemoryNote == null)
				return BadRequest("List with this Id was not found!");

			return Ok(createdMemoryNote.ToReturnDto());
		}

		[HttpPatch("{id:int}")]
		public async Task<IActionResult> UpdateMemoryNote(int id, [FromBody] MemoryNoteUpdateDto memoryNoteUpdateDto)
		{
			var updatedMemoryNote = await _memoryNoteRepository.UpdateMemoryNoteAsync(id, memoryNoteUpdateDto);

			if (updatedMemoryNote == null)
				return NotFound();

			return Ok(updatedMemoryNote.ToReturnDto());
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> DeleteMemoryNote(int id)
		{
			var existingMemoryNote = await _memoryNoteRepository.DeleteMemoryNoteAsync(id);

			if (existingMemoryNote == null)
				return NotFound();

			return NoContent();
		}

	}
}
