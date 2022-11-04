using Data.IRepositories;
using Api.IServices;
using Api.Repositories;
using Data.Context;
using Data.DomainClass;

namespace Api.Services
{
    public class NhanVienService : INhanVienService
    {
        private IDonutOkitaRepository<NhanVien> _iNhanVienRepository;
        public NhanVienService(DonutOkitaContext context)
        {
            _iNhanVienRepository = new DonutOkitaRepository<NhanVien>(context);
        }

        public async Task<bool> Add(NhanVien nv)
        {
            return await _iNhanVienRepository.Add(nv);
        }

        public async Task<IEnumerable<NhanVien>> GetAll()
        {
            return await _iNhanVienRepository.GetAll();
        }

        public async Task<NhanVien?> GetById(Guid id)
        {
            var result = _iNhanVienRepository.GetAll().Result.FirstOrDefault(c => c.Id == id);
            return await Task.FromResult(result);
        }

        public async Task<NhanVien?> IsLogin(string phone, string password)
        {
            var result = _iNhanVienRepository.GetAll().Result.FirstOrDefault(c => c.Sdt == phone && c.MatKhau == password);
            return await Task.FromResult(result);
        }

        public async Task<bool> Remove(NhanVien nv)
        {
            return await _iNhanVienRepository.Remove(nv);
        }

        public async Task<bool> Update(NhanVien nv)
        {
            return await _iNhanVienRepository.Update(nv);
        }
    }
}
