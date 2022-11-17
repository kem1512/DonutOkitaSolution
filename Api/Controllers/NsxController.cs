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

            var result = await _iNsxService.Update(nsx);

            return result != null ? NoContent() : StatusCode(StatusCodes.Status500InternalServerError, result);
        }

        // POST: api/nsx
        [HttpPost]
        public async Task<ActionResult<Nsx>> Post(Nsx nsx)
        {
            var result = await _iNsxService.Add(nsx);

            return result != null ? CreatedAtAction("Get", new { id = nsx.Id }, nsx) : StatusCode(StatusCodes.Status500InternalServerError, result);
        }

        // DELETE: api/nsx/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var nsx = await _iNsxService.GetById(id);

            if (nsx == null)
            {
                return NotFound();
            }

            var result = await _iNsxService.Remove(nsx);

            return result != null ? NoContent() : StatusCode(StatusCodes.Status500InternalServerError, result);
        }
    }
}
