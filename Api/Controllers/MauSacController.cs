using Microsoft.AspNetCore.Mvc;
using Data.Context;
using Data.DomainClass;
using Data.ViewModels;
using Api.Services;
using Api.IServices;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MauSacController : ControllerBase
    {
        private readonly IMauSacService _iMauSacService;
        public MauSacController(DonutOkitaContext context)
        {
            _iMauSacService = new MauSacService(context);
        }

        // GET: api/mausac
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MauSac>>> Get()
        {
            return Ok(await _iMauSacService.GetAll());
        }

        // GET: api/mausac/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MauSac>> Get(Guid id)
        {
            var result = await _iMauSacService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // PUT: api/mausac/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, MauSac ms)
        {
            if (id != ms.Id)
            {
                return NotFound();
            }

            var result = await _iMauSacService.Update(ms);

            return result != null ? NoContent() : StatusCode(StatusCodes.Status500InternalServerError, result);
        }

        // POST: api/mausac
        [HttpPost]
        public async Task<ActionResult<MauSac>> Post(MauSac ms)
        {
            var result = await _iMauSacService.Add(ms);

            return result != null ? CreatedAtAction("Get", new { id = ms.Id }, ms) : StatusCode(StatusCodes.Status500InternalServerError, result);
        }

        // DELETE: api/mausac/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var ms = await _iMauSacService.GetById(id);

            if (ms == null)
            {
                return NotFound();
            }

            var result = await _iMauSacService.Remove(ms);

            return result != null ? NoContent() : StatusCode(StatusCodes.Status500InternalServerError, result);
        }
    }
}
