using Microsoft.AspNetCore.Mvc;
using LibraryAPI.Models;
using LibraryAPI.Services;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public AuthorController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAuthors()
        {
            var authors = await _libraryService.GetAuthorsAsync();

            if (authors == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No data in the database");
            }

            return StatusCode(StatusCodes.Status200OK, authors);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetAuthor(int id, bool includeBooks = true)
        {
            Author author = await _libraryService.GetAuthorAsync(id, includeBooks);

            if (author == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, $"No Author with id: {id} found.");
            }

            return StatusCode(StatusCodes.Status200OK, author);
        }

        [HttpPost]
        public async Task<ActionResult<Author>> AddAuthor(Author author)
        {
            var dbAuthor = await _libraryService.AddAuthorAsync(author);

            if (dbAuthor == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{author.Name} can not be added.");
            }

            return CreatedAtAction("GetAuthor", new { id = author.Id }, author);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateAuthor(int id, Author author)
        {
            if (id != author.Id)
            {
                return BadRequest();
            }

            Author dbAuthor = await _libraryService.UpdateAuthorAsync(author);

            if (dbAuthor == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{author.Name} can not be updated");
            }

            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _libraryService.GetAuthorAsync(id, false);
            (bool status, string message) = await _libraryService.DeleteAuthorAsync(author);

            if (status == false)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, message);
            }

            return StatusCode(StatusCodes.Status200OK, author);
        }
    }
}
