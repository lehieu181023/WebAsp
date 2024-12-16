using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAsp.Data;
using WebAsp.Models;

namespace WebAsp.Controllers
{
    public class SinhVienController : Controller
    {
        private readonly WebDbContext _context;

        public SinhVienController(WebDbContext context)
        {
            _context = context;
        }

        // GET: SinhVien
        public async Task<IActionResult> Index()
        {
            var sinhvienlist = await _context.sinhvien.ToListAsync();
            var nganhlist = await _context.nganh.ToListAsync();

            var ViewSV = new ViewSinhVien()
            {
                SinhViens = sinhvienlist,
                nganhs = nganhlist
            };

            return View(ViewSV);
        }

        public IActionResult manage(SinhVien sinhvien, string action)
        {
            switch (action)
            {
                case "Sửa":
                    var existingSinhVien = _context.sinhvien.FirstOrDefault(s => s.IdSinhVien == sinhvien.IdSinhVien);
                    if (existingSinhVien != null)
                    {
                        existingSinhVien.IdNganh = sinhvien.IdNganh;
                        existingSinhVien.KhoaHoc = sinhvien.KhoaHoc;
                        existingSinhVien.HoTen = sinhvien.HoTen;
                        existingSinhVien.NgaySinh = sinhvien.NgaySinh;
                        existingSinhVien.GioiTinh = sinhvien.GioiTinh;

                        _context.sinhvien.Update(existingSinhVien);
                        _context.SaveChanges();
                    }
                    break;
                case "Xóa":
                    var svToDelete = _context.sinhvien.FirstOrDefault(s => s.IdSinhVien == sinhvien.IdSinhVien);
                    if (svToDelete != null)
                    {
                        _context.sinhvien.Remove(svToDelete);
                        _context.SaveChanges();
                    }
                    break;
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Create()
        {
            var nganhlist = await _context.nganh.ToListAsync();
            var sinhvien = new SinhVien();

            var CrSinhVien = new CreateSinhVien()
            {
                sinhvien = sinhvien,
                nganhs = nganhlist
            };

            return View(CrSinhVien);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateSinhVien crSinhVien)
        {
            if (crSinhVien != null)
            {
                _context.sinhvien.Add(crSinhVien.sinhvien);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        private bool sinhvienExists(int id)
        {
            return _context.sinhvien.Any(e => e.IdSinhVien == id);
        }
    }

}
