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
    public class HoaDonController : ControllerBase
    {
        private readonly IHoaDonService _iHoaDonService;
        private readonly ConverToViewModel _converToViewModel;
        public HoaDonController(DonutOkitaContext context)
        {
            _iHoaDonService = new HoaDonService(context);
            _converToViewModel = new ConverToViewModel(context);
        }

        // GET: api/hoadon
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HoaDon>>> Get()
        {
            return Ok(await _iHoaDonService.GetAll());
        }

        [HttpGet("GetHoaDonViewModel")]
        public ActionResult<IEnumerable<HoaDonViewModel>> GetHoaDonViewModel()
        {
            return Ok(_converToViewModel.HoaDonViewModels().Result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HoaDon>> Get(Guid id)
        {
            var result = await _iHoaDonService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // PUT: api/hoadon/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, HoaDon hd)
        {
            if (id != hd.Id)
            {
                return NotFound();
            }

            if (!await _iHoaDonService.Update(hd))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        // POST: api/hoadon
        [HttpPost]
        public async Task<ActionResult<HoaDon>> Post(HoaDon hd)
        {
            if (!await _iHoaDonService.Add(hd))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return CreatedAtAction("Get", new { id = hd.Id }, hd);
        }

        // DELETE: api/hoadon/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _iHoaDonService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            if (!await _iHoaDonService.Remove(result))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }
    }
}
