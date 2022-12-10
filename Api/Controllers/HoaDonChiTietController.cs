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
    public class HoaDonChiTietController : ControllerBase
    {
        private readonly IHoaDonChiTietService _iHoaDonChiTietService;
        public HoaDonChiTietController(DonutOkitaContext context)
        {
            _iHoaDonChiTietService = new HoaDonChiTietService(context);
        }

        // GET: api/hoadonchitiet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HoaDonChiTiet>>> Get()
        {
            return Ok(await _iHoaDonChiTietService.GetAll());
        }

        // GET: api/hoadonchitiet/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<HoaDonChiTiet>>> Get(Guid id)
        {
            var result = await _iHoaDonChiTietService.GetAll();

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result.Where(c => c.IdHoaDon == id));
        }

        // PUT: api/hoadonchitiet/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, HoaDonChiTiet sp)
        {
            if (id != sp.IdHoaDon || id != sp.IdChiTietSp)
            {
                return NotFound();
            }

            var result = await _iHoaDonChiTietService.Update(sp);

            return result == null ? NoContent() : StatusCode(StatusCodes.Status500InternalServerError, result);
        }

        // POST: api/hoadonchitiet
        [HttpPost]
        public async Task<ActionResult<HoaDonChiTiet>> Post(HoaDonChiTiet sp)
        {
            var result = await _iHoaDonChiTietService.Add(sp);

            return result == null ? CreatedAtAction("Get", new { id = sp.IdHoaDon }, sp) : StatusCode(StatusCodes.Status500InternalServerError, result);
        }

        // DELETE: api/hoadonchitiet/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var hdct = await _iHoaDonChiTietService.GetById(id);

            if (hdct == null)
            {
                return NotFound();
            }

            var result = await _iHoaDonChiTietService.Add(hdct);

            return result == null ? NoContent() : StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
