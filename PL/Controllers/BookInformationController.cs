using BLL.Models;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookInformationController : ControllerBase
    {
        private readonly IBookService _service;

        public BookInformationController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookDTOModel>>> GetAllAsync()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("id")]
        public async Task<ActionResult<BookDTOModel>> GetAsync(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpGet("isbn")]
        public async Task<ActionResult<BookDTOModel>> GetByISBNAsync(string ISBN)
        {
            return Ok(await _service.GetByISBNAsync(ISBN));
        }

        [Authorize(Roles="Admin")]
        [HttpPut("id")]
        public async Task<IActionResult> UpdateAsync(int id, BookDTOModel model)
        {
            await _service.UpdateAsync(id, model);

            return Ok();
        }

        [Authorize(Roles="Admin")]
        [HttpPost("id")]
        public async Task<ActionResult> AddAsync(BookDTOModel model)
        {
            await _service.AddAsync(model);

            return Ok();
        }

        [Authorize(Roles="Admin")]
        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);

            return Ok();
        }
    }
}
