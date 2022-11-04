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

            if (!await _iMauSacService.Update(ms))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        // POST: api/mausac
        [HttpPost]
        public async Task<ActionResult<MauSac>> Post(MauSac ms)
        {
            if (!await _iMauSacService.Add(ms))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return CreatedAtAction("Get", new { id = ms.Id }, ms);
        }

        // DELETE: api/mausac/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _iMauSacService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            if (!await _iMauSacService.Remove(result))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }
    }
}
