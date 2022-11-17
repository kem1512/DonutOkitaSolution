using Data.IRepositories;
using Api.IServices;
using Api.Repositories;
using Data.Context;
using Data.DomainClass;

namespace Api.Services
{
    public class MauSacService : IMauSacService
    {
        private IDonutOkitaRepository<MauSac> _iMauSacRepository;
        public MauSacService(DonutOkitaContext context)
        {
            _iMauSacRepository = new DonutOkitaRepository<MauSac>(context);
        }

        public async Task<string?> Add(MauSac ms)
        {
            return await _iMauSacRepository.Add(ms);
        }

        public async Task<IEnumerable<MauSac>> GetAll()
        {
            return await _iMauSacRepository.GetAll();
        }

        public async Task<MauSac?> GetById(Guid id)
        {
            var result = _iMauSacRepository.GetAll().Result.FirstOrDefault(c => c.Id == id);
            return await Task.FromResult(result);
        }

        public async Task<string?> Remove(MauSac ms)
        {
            return await _iMauSacRepository.Remove(ms);
        }

        public async Task<string?> Update(MauSac ms)
        {
            return await _iMauSacRepository.Update(ms);
        }
    }
}
