using BLL.Models;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookGenreController : ControllerBase
    {
        private readonly IGenreService _service;

        public BookGenreController(IGenreService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<GenreDTOModel>>> GetAllAsync()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("id")]
        public async Task<ActionResult<GenreDTOModel>> GetAsync(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }
    }
}
