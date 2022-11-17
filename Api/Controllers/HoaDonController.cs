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
        public async Task<ActionResult<IEnumerable<HoaDonViewModel>>> GetHoaDonViewModel()
        {
            return Ok(await _converToViewModel.HoaDonViewModels());
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

            var result = await _iHoaDonService.Update(hd);

            return result != null ? NoContent() : StatusCode(StatusCodes.Status500InternalServerError, result);
        }

        // POST: api/hoadon
        [HttpPost]
        public async Task<ActionResult<HoaDon>> Post(HoaDon hd)
        {
            var result = await _iHoaDonService.Add(hd);

            return result != null ? CreatedAtAction("Get", new { id = hd.Id }, hd) : StatusCode(StatusCodes.Status500InternalServerError, result);
        }

        // DELETE: api/hoadon/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var hd = await _iHoaDonService.GetById(id);

            if (hd == null)
            {
                return NotFound();
            }

            var result = await _iHoaDonService.Remove(hd);

            return result != null ? NoContent() : StatusCode(StatusCodes.Status500InternalServerError, result);
        }
    }
}
