using Data.IRepositories;
using Api.IServices;
using Api.Repositories;
using Data.Context;
using Data.DomainClass;

namespace Api.Services
{
    public class CuaHangService : ICuaHangService
    {
        private IDonutOkitaRepository<CuaHang> _iCuaHangRepository;
        public CuaHangService(DonutOkitaContext context)
        {
            _iCuaHangRepository = new DonutOkitaRepository<CuaHang>(context);
        }

        public async Task<string?> Add(CuaHang ch)
        {
            return await _iCuaHangRepository.Add(ch);
        }

        public async Task<IEnumerable<CuaHang>> GetAll()
        {
            return await _iCuaHangRepository.GetAll();
        }

        public async Task<CuaHang?> GetById(Guid id)
        {
            var result = _iCuaHangRepository.GetAll().Result.FirstOrDefault(c => c.Id == id);
            return await Task.FromResult(result);
        }

        public async Task<string?> Remove(CuaHang ch)
        {
            return await _iCuaHangRepository.Remove(ch);
        }

        public async Task<string?> Update(CuaHang ch)
        {
            return await _iCuaHangRepository.Update(ch);
        }
    }
}
