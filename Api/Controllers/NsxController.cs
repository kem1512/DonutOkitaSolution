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
    public class NsxController : ControllerBase
    {
        private readonly INsxService _iNsxService;
        public NsxController(DonutOkitaContext context)
        {
            _iNsxService = new NsxService(context);
        }

        // GET: api/nsx
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nsx>>> Get()
        {
            return Ok(await _iNsxService.GetAll());
        }

        // GET: api/nsx/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nsx>> Get(Guid id)
        {
            var result = await _iNsxService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // PUT: api/nsx/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, Nsx nsx)
        {
            if (id != nsx.Id)
            {
                return NotFound();
            }

            if (!await _iNsxService.Update(nsx))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        // POST: api/nsx
        [HttpPost]
        public async Task<ActionResult<Nsx>> Post(Nsx nsx)
        {
            if (!await _iNsxService.Add(nsx))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return CreatedAtAction("Get", new { id = nsx.Id }, nsx);
        }

        // DELETE: api/nsx/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _iNsxService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            if (!await _iNsxService.Remove(result))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }
    }
}
