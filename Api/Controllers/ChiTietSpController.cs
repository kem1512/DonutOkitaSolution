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
    public class ChiTietSpController : ControllerBase
    {
        private readonly IChiTietSpService _iChiTietSpService;
        public ChiTietSpController(DonutOkitaContext context)
        {
            _iChiTietSpService = new ChiTietSpService(context);
        }

        // GET: api/chitietsp
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChiTietSp>>> Get()
        {
            return Ok(await _iChiTietSpService.GetAll());
        }

        // GET: api/chitietsp/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ChiTietSp>> Get(Guid id)
        {
            var result = await _iChiTietSpService.GetByProperties(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // PUT: api/chitietsp/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, ChiTietSp ctsp)
        {
            if (id != ctsp.Id)
            {
                return NotFound();
            }

            if (!await _iChiTietSpService.Update(ctsp))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        // POST: api/chitietsp
        [HttpPost]
        public async Task<ActionResult<ChiTietSp>> Post(ChiTietSp ctsp)
        {
            if (!await _iChiTietSpService.Add(ctsp))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return CreatedAtAction("Get", new { id = ctsp.Id }, ctsp);
        }

        // DELETE: api/chitietsp/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _iChiTietSpService.GetByProperties(id);

            if (result == null)
            {
                return NotFound();
            }

            if (!await _iChiTietSpService.Remove(result))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }
    }
}
