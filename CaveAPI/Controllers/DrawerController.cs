using Dal.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;


namespace CaveAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class DrawerController : ControllerBase
    {
        private readonly IDrawerRepository _drawerRepository;

        // Constructeur injectant le repository des drawers.
        public DrawerController(IDrawerRepository drawerRepository)
        {
            _drawerRepository = drawerRepository;
        }

        // Action GET pour récupérer tous les drawers.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Drawer>>> GetAllDrawers()
        {
            var drawers = await _drawerRepository.GetAllAsync();
            return Ok(drawers);
        }
        // Action POST pour ajouter un nouveau drawer.
        [HttpPost]
        public async Task<ActionResult<Drawer>> PostDrawer(Drawer drawer)
        {
            var createdDrawer = await _drawerRepository.PostAsync(drawer);
            return CreatedAtAction(nameof(GetAllDrawers), new { id = createdDrawer.Id }, createdDrawer);
        }

        // Action PUT pour mettre à jour un drawer existant.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDrawer(int id, Drawer drawer)
        {
            if (id != drawer.Id)
            {
                return BadRequest();
            }

            await _drawerRepository.UpdateUserAsync(drawer);
            return NoContent();
        }

        // Action DELETE pour supprimer un drawer par son identifiant.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrawer(int id)
        {
            await _drawerRepository.DeleteUserAsync(id);
            return NoContent();
        }
    }
}