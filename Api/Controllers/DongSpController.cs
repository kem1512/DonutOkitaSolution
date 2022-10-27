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
    public class DongSpController : ControllerBase
    {
        private readonly IDongSpService _iDongSpService;
        public DongSpController(DonutOkitaContext context)
        {
            _iDongSpService = new DongSpService(context);
        }

        // GET: api/dongsp
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DongSp>>> Get()
        {
            return Ok(await _iDongSpService.GetAll());
        }

        // GET: api/dongsp/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DongSp>> Get(Guid id)
        {
            var result = await _iDongSpService.GetByProperties(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // PUT: api/dongsp/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, DongSp dsp)
        {
            if (id != dsp.Id)
            {
                return NotFound();
            }

            if (!await _iDongSpService.Update(dsp))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        // POST: api/dongsp
        [HttpPost]
        public async Task<ActionResult<DongSp>> Post(DongSp dsp)
        {
            if (!await _iDongSpService.Add(dsp))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return CreatedAtAction("Get", new { id = dsp.Id }, dsp);
        }

        // DELETE: api/dongsp/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _iDongSpService.GetByProperties(id);

            if (result == null)
            {
                return NotFound();
            }

            if (!await _iDongSpService.Remove(result))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }
    }
}
