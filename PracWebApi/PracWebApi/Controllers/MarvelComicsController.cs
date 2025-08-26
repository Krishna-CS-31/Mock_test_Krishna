using Microsoft.AspNetCore.Mvc;
using PracWebApi.Models;
using PracWebApi.Repositories;

namespace PracWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarvelComicsController : ControllerBase
    {
        private readonly IMarvelComicsRepository _repository;

        public MarvelComicsController(IMarvelComicsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarvelComics>>> GetComics()
        {
            var comics = await _repository.GetAllAsync();
            return Ok(comics);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MarvelComics>> GetComic(int id)
        {
            var comic = await _repository.GetByIdAsync(id);
            return comic == null ? NotFound() : Ok(comic);
        }

        [HttpPost]
        public async Task<ActionResult<MarvelComics>> CreateComic(MarvelComics comic)
        {
            var created = await _repository.AddAsync(comic);
            return CreatedAtAction(nameof(GetComic), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComic(int id, MarvelComics comic)
        {
            if (id != comic.Id) return BadRequest();
            var updated = await _repository.UpdateAsync(comic);
            return updated ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComic(int id)
        {
            var deleted = await _repository.DeleteAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
