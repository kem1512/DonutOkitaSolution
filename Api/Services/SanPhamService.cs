using Data.IRepositories;
using Api.IServices;
using Data.ViewModels;
using Api.Repositories;
using Data.Context;
using Data.DomainClass;

namespace Api.Services
{
    public class SanPhamService : ISanPhamService
    {
        private IDonutOkitaRepository<SanPham> _iSanPhamSpRepository;
        public SanPhamService(DonutOkitaContext context)
        {
            _iSanPhamSpRepository = new DonutOkitaRepository<SanPham>(context);
        }

        public async Task<string?> Add(SanPham sp)
        {
            return await _iSanPhamSpRepository.Add(sp);
        }

        public async Task<string?> Remove(SanPham sp)
        {
            return await _iSanPhamSpRepository.Remove(sp);
        }

        public async Task<IEnumerable<SanPham>> GetAll()
        {
            return await _iSanPhamSpRepository.GetAll();
        }

        public async Task<string?> Update(SanPham sp)
        {
            return await _iSanPhamSpRepository.Update(sp);
        }

        public async Task<SanPham?> GetById(Guid id)
        {
            var result = _iSanPhamSpRepository.GetAll().Result.FirstOrDefault(c => c.Id == id);
            return await Task.FromResult(result);
        }
    }
}
