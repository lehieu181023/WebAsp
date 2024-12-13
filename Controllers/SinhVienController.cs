using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

            var ViewSV = new ViewSinhVien() {
                SinhViens = sinhvienlist,
                nganhs = nganhlist
            };

            return View(ViewSV);
        }

        

        private bool sinhvienExists(int id)
        {
            return _context.sinhvien.Any(e => e.IdSinhVien == id);
        }
    }
    
}
