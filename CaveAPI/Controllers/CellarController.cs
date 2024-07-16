using Dal.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace CaveAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CellarController : ControllerBase
    {
        private readonly ICellarRepository _cellarRepository;

        public CellarController(ICellarRepository cellarRepository)
        {
            _cellarRepository = cellarRepository;
        }

        // Récuperation de requête API
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cellar>>> GetCellars()
        {
            var cellars = await _cellarRepository.GetCellarsAsync();
            return Ok(cellars);
        }

        // Récuperation de requête API
        [HttpGet("{id}")]
        public async Task<ActionResult<Cellar>> GetCellar(int id)
        {
            var cellar = await _cellarRepository.GetCellarByIDAsync(id);

            if (cellar == null)
            {
                return NotFound();
            }

            return Ok(cellar);
        }

        // Envoie une requête API
        [HttpPost]
        public async Task<ActionResult<Cellar>> CreateCellar(Cellar cellar)
        {
            await _cellarRepository.CreateCeallarAsync(cellar);
            return CreatedAtAction(nameof(GetCellar), new { id = cellar.Id }, cellar);
        }

        // Afficher une requête API
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCellar(int id, Cellar cellar)
        {
            if (id != cellar.Id)
            {
                return BadRequest();
            }

            await _cellarRepository.UpdateCellarAsync(cellar);
            return NoContent();
        }

        // Effacer une requête API
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCellar(int id)
        {
            await _cellarRepository.DeleteCellarAsync(id);
            return NoContent();
        }
    }
}
