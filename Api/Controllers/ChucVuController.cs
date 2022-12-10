using Microsoft.AspNetCore.Mvc;
using Data.Context;
using Data.DomainClass;
using Data.ViewModels;
using Api.Services;
using Api.IServices;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Api.Controllers
{
    [Authorize]
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
            var result = await _iChucVuService.GetById(id);

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

            var result = await _iChucVuService.Update(cv);

            return result == null ? NoContent() : StatusCode(StatusCodes.Status500InternalServerError, result);
        }

        // POST: api/chucvu
        [HttpPost]
        public async Task<ActionResult<ChucVu>> Post(ChucVu cv)
        {
            var result = await _iChucVuService.Add(cv);

            return result == null ? CreatedAtAction("Get", new { id = cv.Id }, cv) : StatusCode(StatusCodes.Status500InternalServerError);
        }

        // DELETE: api/chucvu/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var cv = await _iChucVuService.GetById(id);

            if (cv == null)
            {
                return NotFound();
            }

            var result = _iChucVuService.Remove(cv);

            return result != null ? NoContent() : StatusCode(StatusCodes.Status500InternalServerError, result);
        }
    }
}
