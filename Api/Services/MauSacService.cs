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

        public async Task<bool> Add(MauSac ms)
        {
            return await _iMauSacRepository.Add(ms);
        }

        public async Task<IEnumerable<MauSac>> GetAll()
        {
            return await _iMauSacRepository.GetAll();
        }

        public async Task<MauSac?> GetByProperties<T>(T val)
        {
            return await _iMauSacRepository.GetByProperties(val);
        }

        public async Task<bool> Remove(MauSac ms)
        {
            return await _iMauSacRepository.Remove(ms);
        }

        public async Task<bool> Update(MauSac ms)
        {
            return await _iMauSacRepository.Update(ms);
        }
    }
}
