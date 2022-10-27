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
    public class SanPhamController : ControllerBase
    {
        private readonly ISanPhamService _iSanPhamService;
        private readonly ConverToViewModel _converToViewModel;
        public SanPhamController(DonutOkitaContext context)
        {
            _iSanPhamService = new SanPhamService(context);
            _converToViewModel = new ConverToViewModel(context);
        }

        // GET: api/sanpham
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SanPham>>> Get()
        {
            return Ok(await _iSanPhamService.GetAll());
        }

        [HttpGet("GetSanPhamViewModel")]
        public ActionResult<IEnumerable<SanPhamViewModel>> GetSanPhamViewModel()
        {
            return Ok(_converToViewModel.SanPhamViewModels().Result);
        }

        // GET: api/sanpham/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SanPham>> Get(Guid id)
        {
            var result = await _iSanPhamService.GetByProperties(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // PUT: api/sanpham/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, SanPham sp)
        {
            if (id != sp.Id)
            {
                return NotFound();
            }

            if (!await _iSanPhamService.Update(sp))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        // POST: api/sanpham
        [HttpPost]
        public async Task<ActionResult<SanPham>> Post(SanPham sp)
        {
            if (!await _iSanPhamService.Add(sp))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return CreatedAtAction("Get", new { id = sp.Id }, sp);
        }

        // DELETE: api/sanpham/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _iSanPhamService.GetByProperties(id);

            if (result == null)
            {
                return NotFound();
            }

            if (!await _iSanPhamService.Remove(result))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }
    }
}
