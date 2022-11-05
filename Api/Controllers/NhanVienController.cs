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

        [HttpGet("GetNhanVienViewModel/{id}")]
        public async Task<ActionResult<IEnumerable<NhanVienViewModel>>> GetNhanVienViewModelById(Guid id)
        {
            return Ok(await _converToViewModel.NhanVienViewModelById(id));
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

            if (!await _iNhanVienService.Update(nv))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        // POST: api/nhanvien
        [HttpPost]
        public async Task<ActionResult<NhanVien>> Post(NhanVien nv)
        {
            if (!await _iNhanVienService.Add(nv))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return CreatedAtAction("Get", new { id = nv.Id }, nv);
        }

        // DELETE: api/nhanvien/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _iNhanVienService.GetById(id);

            if (result == null)
            {
                return NotFound();
            }

            if (!await _iNhanVienService.Remove(result))
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }
    }
}
