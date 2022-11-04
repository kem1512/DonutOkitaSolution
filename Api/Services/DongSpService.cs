using Data.IRepositories;
using Api.IServices;
using Api.Repositories;
using Data.Context;
using Data.DomainClass;

namespace Api.Services
{
    public class DongSpService : IDongSpService
    {
        private IDonutOkitaRepository<DongSp> _iDongSpRepository;
        public DongSpService(DonutOkitaContext context)
        {
            _iDongSpRepository = new DonutOkitaRepository<DongSp>(context);
        }

        public async Task<bool> Add(DongSp dsp)
        {
            return await _iDongSpRepository.Add(dsp);
        }

        public async Task<IEnumerable<DongSp>> GetAll()
        {
            return await _iDongSpRepository.GetAll();
        }

        public async Task<DongSp?> GetById(Guid id)
        {
            var result = _iDongSpRepository.GetAll().Result.FirstOrDefault(c => c.Id == id);
            return await Task.FromResult(result);
        }

        public async Task<bool> Remove(DongSp dsp)
        {
            return await _iDongSpRepository.Remove(dsp);
        }

        public async Task<bool> Update(DongSp dsp)
        {
            return await _iDongSpRepository.Update(dsp);
        }
    }
}
