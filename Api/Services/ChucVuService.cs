using Data.IRepositories;
using Api.IServices;
using Api.Repositories;
using Data.Context;
using Data.DomainClass;

namespace Api.Services
{
    public class ChucVuService : IChucVuService
    {
        private IDonutOkitaRepository<ChucVu> _iChucVuRepository;
        public ChucVuService(DonutOkitaContext context)
        {
            _iChucVuRepository = new DonutOkitaRepository<ChucVu>(context);
        }

        public async Task<bool> Add(ChucVu cv)
        {
            return await _iChucVuRepository.Add(cv);
        }

        public async Task<IEnumerable<ChucVu>> GetAll()
        {
            return await _iChucVuRepository.GetAll();
        }

        public async Task<ChucVu?> GetByProperties<T>(T val)
        {
            return await _iChucVuRepository.GetByProperties(val);
        }

        public async Task<bool> Remove(ChucVu cv)
        {
            return await _iChucVuRepository.Remove(cv);
        }

        public async Task<bool> Update(ChucVu cv)
        {
            return await _iChucVuRepository.Update(cv);
        }
    }
}
