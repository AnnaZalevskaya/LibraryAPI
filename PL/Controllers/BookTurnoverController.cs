using BLL.Models;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookTurnoverController : ControllerBase
    {
        private readonly IBookTurnoverService _service;

        public BookTurnoverController(IBookTurnoverService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookTurnoverDTOModel>>> GetAllAsync()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("id")]
        public async Task<ActionResult<BookTurnoverDTOModel>> GetAsync(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [Authorize(Roles="Client")]
        [HttpPost("Id")]
        public async Task<ActionResult> AddAsync(BookTurnoverUserDTOModel model)
        {
            await _service.AddAsync(model);

            return Ok();
        }

        [Authorize(Roles="Client")]
        [HttpPut("Id")]
        public async Task<IActionResult> UpdateAsync(int id, BookTurnoverUserDTOModel model)
        {
            await _service.UpdateAsync(id, model);

            return Ok();
        }

        [Authorize(Roles="Client")]
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);

            return Ok();
        }
    }
}
