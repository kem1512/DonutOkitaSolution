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
            var result = await _iDongSpService.GetById(id);

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

            var result = await _iDongSpService.Update(dsp);

            return result == null ? NoContent() : StatusCode(StatusCodes.Status500InternalServerError, result);
        }

        // POST: api/dongsp
        [HttpPost]
        public async Task<ActionResult<DongSp>> Post(DongSp dsp)
        {
            var result = await _iDongSpService.Add(dsp);

            return result == null ? CreatedAtAction("Get", new { id = dsp.Id }, dsp) : StatusCode(StatusCodes.Status500InternalServerError, result);
        }

        // DELETE: api/dongsp/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var cv = await _iDongSpService.GetById(id);

            if (cv == null)
            {
                return NotFound();
            }

            var result = _iDongSpService.Remove(cv);

            return result != null ? NoContent() : StatusCode(StatusCodes.Status500InternalServerError, result);
        }
    }
}
