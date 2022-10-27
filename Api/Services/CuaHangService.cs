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

        public async Task<bool> Add(CuaHang ch)
        {
            return await _iCuaHangRepository.Add(ch);
        }

        public async Task<IEnumerable<CuaHang>> GetAll()
        {
            return await _iCuaHangRepository.GetAll();
        }

        public async Task<CuaHang?> GetByProperties<T>(T val)
        {
            return await _iCuaHangRepository.GetByProperties(val);
        }

        public async Task<bool> Remove(CuaHang ch)
        {
            return await _iCuaHangRepository.Remove(ch);
        }

        public async Task<bool> Update(CuaHang ch)
        {
            return await _iCuaHangRepository.Update(ch);
        }
    }
}
