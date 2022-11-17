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

        public async Task<string?> Add(Nsx nsx)
        {
            return await _iNsxRepository.Add(nsx);
        }

        public Task<IEnumerable<Nsx>> GetAll()
        {
            return _iNsxRepository.GetAll();
        }

        public async Task<Nsx?> GetById(Guid id)
        {
            var result = _iNsxRepository.GetAll().Result.FirstOrDefault(c => c.Id == id);
            return await Task.FromResult(result);
        }

        public Task<string?> Remove(Nsx nsx)
        {
            return _iNsxRepository.Remove(nsx);
        }

        public Task<string?> Update(Nsx nsx)
        {
            return _iNsxRepository.Update(nsx);
        }
    }
}
