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

        public async Task<string?> Add(HoaDon hd)
        {
            return await _iHoaDonRepository.Add(hd);
        }

        public async Task<IEnumerable<HoaDon>> GetAll()
        {
            return await _iHoaDonRepository.GetAll();
        }

        public async Task<HoaDon?> GetById(Guid id)
        {
            var result = _iHoaDonRepository.GetAll().Result.FirstOrDefault(c => c.Id == id);
            return await Task.FromResult(result);
        }

        public async Task<string?> Remove(HoaDon hd)
        {
            return await _iHoaDonRepository.Remove(hd);
        }

        public async Task<string?> Update(HoaDon hd)
        {
            return await _iHoaDonRepository.Update(hd);
        }
    }
}
