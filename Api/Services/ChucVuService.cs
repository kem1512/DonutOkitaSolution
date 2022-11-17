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

        public async Task<string?> Add(ChucVu cv)
        {
            return await _iChucVuRepository.Add(cv);
        }

        public async Task<IEnumerable<ChucVu>> GetAll()
        {
            return await _iChucVuRepository.GetAll();
        }

        public async Task<ChucVu?> GetById(Guid id)
        {
            var result = _iChucVuRepository.GetAll().Result.FirstOrDefault(c => c.Id == id);
            return await Task.FromResult(result);
        }

        public async Task<string?> Remove(ChucVu cv)
        {
            return await _iChucVuRepository.Remove(cv);
        }

        public async Task<string?> Update(ChucVu cv)
        {
            return await _iChucVuRepository.Update(cv);
        }
    }
}
