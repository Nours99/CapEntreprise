using Dal.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaveAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrawerController : ControllerBase
    {
        readonly IDrawerRepository _drawerRepository;
        public DrawerController(IDrawerRepository drawerRepository)
        {
            _drawerRepository = drawerRepository;
        }
    }
}
