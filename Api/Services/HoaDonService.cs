using Data.IRepositories;
using Api.IServices;
using Api.Repositories;
using Data.Context;
using Data.DomainClass;

namespace Api.Services
{
    public class HoaDonService : IHoaDonService
    {
        private IDonutOkitaRepository<HoaDon> _iHoaDonRepository;
        public HoaDonService(DonutOkitaContext context)
        {
            _iHoaDonRepository = new DonutOkitaRepository<HoaDon>(context);
        }

        public async Task<bool> Add(HoaDon hd)
        {
            return await _iHoaDonRepository.Add(hd);
        }

        public async Task<IEnumerable<HoaDon>> GetAll()
        {
            return await _iHoaDonRepository.GetAll();
        }

        public async Task<HoaDon?> GetByProperties<T>(T val)
        {
            return await _iHoaDonRepository.GetByProperties(val);
        }

        public async Task<bool> Remove(HoaDon hd)
        {
            return await _iHoaDonRepository.Remove(hd);
        }

        public async Task<bool> Update(HoaDon hd)
        {
            return await _iHoaDonRepository.Update(hd);
        }
    }
}
