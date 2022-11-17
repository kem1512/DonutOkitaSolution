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
            var result = await _iChiTietSpService.GetById(id);

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

            var result = await _iChiTietSpService.Update(ctsp);

            return result != null ? NoContent() : StatusCode(StatusCodes.Status500InternalServerError, result);
        }

        // POST: api/chitietsp
        [HttpPost]
        public async Task<ActionResult<ChiTietSp>> Post(ChiTietSp ctsp)
        {
            var result = await _iChiTietSpService.Add(ctsp);

            return result != null ? CreatedAtAction("Get", new { id = ctsp.Id }, ctsp) : StatusCode(StatusCodes.Status500InternalServerError);
        }

        // DELETE: api/chitietsp/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var ctsp = await _iChiTietSpService.GetById(id);

            if (ctsp == null)
            {
                return NotFound();
            }

            var result = _iChiTietSpService.Remove(ctsp);

            return result != null ? NoContent() : StatusCode(StatusCodes.Status500InternalServerError, result);
        }
    }
}
