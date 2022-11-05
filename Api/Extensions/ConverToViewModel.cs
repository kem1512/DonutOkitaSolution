using Data.IRepositories;
using Data.ViewModels;
using Api.Repositories;
using Data.Context;
using Data.DomainClass;

namespace Api.Services
{
    public class ConverToViewModel
    {
        private IDonutOkitaRepository<ChiTietSp> _iChiTietSpRepository;
        private IDonutOkitaRepository<SanPham> _iSanPhamSpRepository;
        private IDonutOkitaRepository<Nsx> _iNsxRepository;
        private IDonutOkitaRepository<DongSp> _iDongSpRepository;
        private IDonutOkitaRepository<MauSac> _iMauSacRepository;
        private IDonutOkitaRepository<HoaDon> _iHoaDonRepository;
        private IDonutOkitaRepository<HoaDonChiTiet> _iHoaDonChiTietRepository;
        private IDonutOkitaRepository<ChucVu> _iChucVuRepository;
        private IDonutOkitaRepository<CuaHang> _iCuaHangRepository;
        private IDonutOkitaRepository<NhanVien> _iNhanVienRepository;

        public ConverToViewModel(DonutOkitaContext context)
        {
            _iMauSacRepository = new DonutOkitaRepository<MauSac>(context);
            _iSanPhamSpRepository = new DonutOkitaRepository<SanPham>(context);
            _iNsxRepository = new DonutOkitaRepository<Nsx>(context);
            _iDongSpRepository = new DonutOkitaRepository<DongSp>(context);
            _iChiTietSpRepository = new DonutOkitaRepository<ChiTietSp>(context);
            _iHoaDonChiTietRepository = new DonutOkitaRepository<HoaDonChiTiet>(context);
            _iHoaDonRepository = new DonutOkitaRepository<HoaDon>(context);
            _iChucVuRepository = new DonutOkitaRepository<ChucVu>(context);
            _iCuaHangRepository = new DonutOkitaRepository<CuaHang>(context);
            _iNhanVienRepository = new DonutOkitaRepository<NhanVien>(context);
        }
        public Task<IEnumerable<SanPhamViewModel>> SanPhamViewModels()
        {
            var result = from ctsp in _iChiTietSpRepository.GetAll().Result
                         join sp in _iSanPhamSpRepository.GetAll().Result on ctsp.IdSp equals sp.Id
                         join ms in _iMauSacRepository.GetAll().Result on ctsp.IdMauSac equals ms.Id
                         join dsp in _iDongSpRepository.GetAll().Result on ctsp.IdDongSp equals dsp.Id
                         join nsx in _iNsxRepository.GetAll().Result on ctsp.IdNsx equals nsx.Id
                         select new SanPhamViewModel()
                         {
                             ChiTietSp = ctsp,
                             SanPham = sp,
                             MauSac = ms,
                             DongSp = dsp,
                             Nsx = nsx
                         };
            return Task.FromResult(result);
        }

        public Task<IEnumerable<HoaDonViewModel>> HoaDonViewModels()
        {
            var result = from hd in _iHoaDonRepository.GetAll().Result
                                  join cthd in _iHoaDonChiTietRepository.GetAll().Result on hd.Id equals cthd.IdHoaDon
                                  select new HoaDonViewModel() { HoaDon = hd, HoaDonChiTiet = cthd };
            return Task.FromResult(result);
        }

        public Task<IEnumerable<NhanVienViewModel>> NhanVienViewModels()
        {
            var result = from nv in _iNhanVienRepository.GetAll().Result
                         join ch in _iCuaHangRepository.GetAll().Result on nv.IdCh equals ch.Id
                         join cv in _iChucVuRepository.GetAll().Result on nv.IdCv equals cv.Id
                         select new NhanVienViewModel() { NhanVien = nv, CuaHang = ch, ChucVu = cv };
            return Task.FromResult(result);
        }

        public Task<NhanVienViewModel> NhanVienViewModelById(Guid id)
        {
            var result = (from nv in _iNhanVienRepository.GetAll().Result
                         join ch in _iCuaHangRepository.GetAll().Result on nv.IdCh equals ch.Id
                         join cv in _iChucVuRepository.GetAll().Result on nv.IdCv equals cv.Id
                         where nv.Id == id select new NhanVienViewModel() { NhanVien = nv, CuaHang = ch, ChucVu = cv }).First();
            return Task.FromResult(result);
        }
    }
}
