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
    public class ChucVuController : ControllerBase
    {
        private readonly IChucVuService _iChucVuService;
        public ChucVuController(DonutOkitaContext context)
        {
            _iChucVuService = new ChucVuService(context);
        }

        // GET: api/chucvu
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChucVu>>> Get()
        {
            return Ok(await _iChucVuService.GetAll());
        }

        // GET: api/chucvu/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChucVu>> Get(Guid id)
        {
            var result = await _iChucVuService.GetByProperties(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // PUT: api/chucvu/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, ChucVu cv)
        {
            if (id != cv.Id)
            {
                return NotFound();
            }

            if (!await _iChucVuService.Update(cv))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        // POST: api/chucvu
        [HttpPost]
        public async Task<ActionResult<ChucVu>> Post(ChucVu cv)
        {
            if (!await _iChucVuService.Add(cv))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return CreatedAtAction("Get", new { id = cv.Id }, cv);
        }

        // DELETE: api/chucvu/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _iChucVuService.GetByProperties(id);

            if (result == null)
            {
                return NotFound();
            }

            if (!await _iChucVuService.Remove(result))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }
    }
}
