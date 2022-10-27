using Data.IRepositories;
using Api.IServices;
using Api.Repositories;
using Data.Context;
using Data.DomainClass;

namespace Api.Services
{
    public class ChiTietSpService : IChiTietSpService
    {
        private IDonutOkitaRepository<ChiTietSp> _iChiTietSpRepository;
        public ChiTietSpService(DonutOkitaContext context)
        {
            _iChiTietSpRepository = new DonutOkitaRepository<ChiTietSp>(context);
        }

        public async Task<bool> Add(ChiTietSp ctsp)
        {
            return await _iChiTietSpRepository.Add(ctsp);
        }

        public async Task<IEnumerable<ChiTietSp>> GetAll()
        {
            return await _iChiTietSpRepository.GetAll();
        }

        public async Task<ChiTietSp?> GetByProperties<T>(T val)
        {
            return await _iChiTietSpRepository.GetByProperties(val);
        }

        public async Task<bool> Remove(ChiTietSp ctsp)
        {
            return await _iChiTietSpRepository.Remove(ctsp);
        }

        public async Task<bool> Update(ChiTietSp ctsp)
        {
            return await _iChiTietSpRepository.Update(ctsp);
        }
    }
}
