using Data.IRepositories;
using Api.IServices;
using Api.Repositories;
using Data.Context;
using Data.DomainClass;

namespace Api.Services
{
    public class HoaDonChiTietService : IHoaDonChiTietService
    {
        private IDonutOkitaRepository<HoaDonChiTiet> _iHoaDonChiTietRepository;
        public HoaDonChiTietService(DonutOkitaContext context)
        {
            _iHoaDonChiTietRepository = new DonutOkitaRepository<HoaDonChiTiet>(context);
        }

        public async Task<bool> Add(HoaDonChiTiet hdct)
        {
            return await _iHoaDonChiTietRepository.Add(hdct);
        }

        public async Task<IEnumerable<HoaDonChiTiet>> GetAll()
        {
            return await _iHoaDonChiTietRepository.GetAll();
        }

        public async Task<HoaDonChiTiet?> GetById(Guid id)
        {
            var result = _iHoaDonChiTietRepository.GetAll().Result.FirstOrDefault(c => c.IdChiTietSp == id);
            return await Task.FromResult(result);
        }

        public async Task<bool> Remove(HoaDonChiTiet hdct)
        {
            return await _iHoaDonChiTietRepository.Remove(hdct);
        }

        public async Task<bool> Update(HoaDonChiTiet hdct)
        {
            return await _iHoaDonChiTietRepository.Update(hdct);
        }
    }
}
