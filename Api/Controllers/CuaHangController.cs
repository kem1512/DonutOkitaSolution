using Microsoft.AspNetCore.Mvc;
using Data.Context;
using Data.DomainClass;
using Data.ViewModels;
using Api.Services;
using Api.IServices;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuaHangController : ControllerBase
    {
        private readonly ICuaHangService _iCuaHangService;
        public CuaHangController(DonutOkitaContext context)
        {
            _iCuaHangService = new CuaHangService(context);
        }

        // GET: api/cuahang
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CuaHang>>> Get()
        {
            return Ok(await _iCuaHangService.GetAll());
        }

        // GET: api/cuahang/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CuaHang>> Get(Guid id)
        {
            var result = await _iCuaHangService.GetByProperties(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // PUT: api/cuahang/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, CuaHang ch)
        {
            if (id != ch.Id)
            {
                return NotFound();
            }

            if (!await _iCuaHangService.Update(ch))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        // POST: api/cuahang
        [HttpPost]
        public async Task<ActionResult<CuaHang>> Post(CuaHang ch)
        {
            if (!await _iCuaHangService.Add(ch))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return CreatedAtAction("Get", new { id = ch.Id }, ch);
        }

        // DELETE: api/cuahang/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _iCuaHangService.GetByProperties(id);

            if (result == null)
            {
                return NotFound();
            }

            if (!await _iCuaHangService.Remove(result))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }
    }
}
