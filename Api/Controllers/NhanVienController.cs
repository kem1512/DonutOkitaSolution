using Microsoft.AspNetCore.Mvc;
using Data.Context;
using Data.DomainClass;
using Data.ViewModels;
using Api.Services;
using Api.IServices;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private readonly INhanVienService _iNhanVienService;
        private readonly ConverToViewModel _converToViewModel;
        public NhanVienController(DonutOkitaContext context)
        {
            _iNhanVienService = new NhanVienService(context);
            _converToViewModel = new ConverToViewModel(context);
        }

        // GET: api/nhanvien
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NhanVien>>> Get()
        {
            return Ok(await _iNhanVienService.GetAll());
        }

        [HttpGet("GetNhanVienViewModel")]
        public async Task<ActionResult<IEnumerable<NhanVienViewModel>>> GetNhanVienViewModel()
        {
            return Ok(await _converToViewModel.NhanVienViewModels());
        }

        // GET: api/nhanvien/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NhanVien>> Get(Guid id)
        {
            var result = await _iNhanVienService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // PUT: api/nhanvien/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, NhanVien nv)
        {
            if (id != nv.Id)
            {
                return NotFound();
            }

            var result = await _iNhanVienService.Update(nv);

            return result != null ? NoContent() : StatusCode(StatusCodes.Status500InternalServerError, result);
        }

        // POST: api/nhanvien
        [HttpPost]
        public async Task<ActionResult<NhanVien>> Post(NhanVien nv)
        {
            var result = await _iNhanVienService.Add(nv);

            return result != null ? CreatedAtAction("Get", new { id = nv.Id }, nv) : StatusCode(StatusCodes.Status500InternalServerError, result);
        }

        // DELETE: api/nhanvien/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var nv = await _iNhanVienService.GetById(id);

            if (nv == null)
            {
                return NotFound();
            }

            var result = await _iNhanVienService.Remove(nv);

            return result != null ? NoContent() : StatusCode(StatusCodes.Status500InternalServerError, result);
        }
    }
}
