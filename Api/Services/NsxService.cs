using Data.IRepositories;
using Api.IServices;
using Api.Repositories;
using Data.Context;
using Data.DomainClass;

namespace Api.Services
{
    public class NsxService : INsxService
    {
        private IDonutOkitaRepository<Nsx> _iNsxRepository;
        public NsxService(DonutOkitaContext context)
        {
            _iNsxRepository = new DonutOkitaRepository<Nsx>(context);
        }

        public async Task<bool> Add(Nsx nsx)
        {
            return await _iNsxRepository.Add(nsx);
        }

        public Task<IEnumerable<Nsx>> GetAll()
        {
            return _iNsxRepository.GetAll();
        }

        public async Task<Nsx?> GetByProperties<T>(T val)
        {
            return await _iNsxRepository.GetByProperties(val);
        }

        public Task<bool> Remove(Nsx nsx)
        {
            return _iNsxRepository.Remove(nsx);
        }

        public Task<bool> Update(Nsx nsx)
        {
            return _iNsxRepository.Update(nsx);
        }
    }
}
