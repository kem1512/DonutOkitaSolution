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
    public class SanPhamController : ControllerBase
    {
        private readonly ISanPhamService _iSanPhamService;
        private readonly ConverToViewModel _ConverToViewModel;

        public SanPhamController(DonutOkitaContext context)
        {
            _iSanPhamService = new SanPhamService(context);
            _ConverToViewModel = new ConverToViewModel(context);
        }

        // GET: api/sanpham
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SanPham>>> Get()
        {
            return Ok(await _iSanPhamService.GetAll());
        }

        [HttpGet("GetSanPhamViewModel")]
        public async Task<ActionResult<IEnumerable<SanPhamViewModel>>> GetSanPhamViewModel()
        {
            return Ok(await _ConverToViewModel.SanPhamViewModels());
        }

        // GET: api/sanpham/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SanPham>> Get(Guid id)
        {
            var result = await _iSanPhamService.GetById(id);

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

            var result = await _iSanPhamService.Update(sp);

            return result == null ? NoContent() : StatusCode(StatusCodes.Status500InternalServerError, result);
        }

        // POST: api/sanpham
        [HttpPost]
        public async Task<ActionResult<SanPham>> Post(SanPham sp)
        {
            var result = await _iSanPhamService.Add(sp);

            return result == null ? CreatedAtAction("Get", new { id = sp.Id }, sp) : StatusCode(StatusCodes.Status500InternalServerError, result);
        }

        // DELETE: api/sanpham/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var sp = await _iSanPhamService.GetById(id);

            if (sp == null)
            {
                return NotFound();
            }

            var result = await _iSanPhamService.Remove(sp);

            return result == null ? NoContent() : StatusCode(StatusCodes.Status500InternalServerError, result);
        }
    }
}
