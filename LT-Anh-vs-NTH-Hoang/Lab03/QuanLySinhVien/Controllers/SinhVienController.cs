using Microsoft.AspNetCore.Mvc;
using QuanLySinhVien.Models;

namespace QuanLySinhVien.Controllers
{
    public class SinhVienController : Controller
    {
        private static List<SinhVien> students = new List<SinhVien> {
          new SinhVien {
            Id = 1,
            MaSinhVien = "1880001",
            HoVaTen = "Nguyễn Văn An",
            Email = "an.nguyen@itstudent.edu.vn",
            SoDienThoai = "0912345678",
            NgaySinh = new DateTime(2006, 5, 15)
          },
          new SinhVien {
            Id = 2,
            MaSinhVien = "1880002",
            HoVaTen = "Trần Thị Bình",
            Email = "binh.tran@cs.student.edu.vn",
            SoDienThoai = "0923456789",
            NgaySinh = new DateTime(2006, 8, 20)
          },
          new SinhVien {
            Id = 3,
            MaSinhVien = "1880003",
            HoVaTen = "Lê Hoàng Cường",
            Email = "cuong.le@is.student.edu.vn",
            SoDienThoai = "0934567890",
            NgaySinh = new DateTime(2005, 12, 10)
          },
          new SinhVien {
            Id = 4,
            MaSinhVien = "1880004",
            HoVaTen = "Phạm Thị Diệu",
            Email = "dieu.pham@cs.student.edu.vn",
            SoDienThoai = "0945678901",
            NgaySinh = new DateTime(2006, 3, 25)
          },
          new SinhVien {
            Id = 5,
            MaSinhVien = "1880005",
            HoVaTen = "Hoàng Văn Em",
            Email = "em.hoang@itstudent.edu.vn",
            SoDienThoai = "0956789012",
            NgaySinh = new DateTime(2006, 7, 30)
          }
        };
        public IActionResult Index()
        {
            return View(students);
        }

        public IActionResult Details(int Id)
        {
            var student = students.Find(x => x.Id == Id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Id,MaSinhVien,HoVaTen,Email,SoDienThoai,NgaySinh")] SinhVien sinhvien)
        {
            if (ModelState.IsValid)
            {
                int maxId = students.Any() ? students.Max(s => s.Id) : 0;
                sinhvien.Id = maxId + 1;
                students.Add(sinhvien);
                return RedirectToAction(nameof(Index));
            }
            return View(sinhvien);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = students.Find(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(int id, SinhVien sinhvien)
        //public IActionResult Edit(int id, [Bind("Id,MaSinhVien,HoVaTen,Email,SoDienThoai,NgaySinh")] SinhVien sinhvien)
        {
            if (id != sinhvien.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(sinhvien);

            var existingStudent = students.Find(s => s.Id == id);
            if (existingStudent == null)
                return NotFound();

            existingStudent.MaSinhVien = sinhvien.MaSinhVien;
            existingStudent.HoVaTen = sinhvien.HoVaTen;
            existingStudent.Email = sinhvien.Email;
            existingStudent.SoDienThoai = sinhvien.SoDienThoai;
            existingStudent.NgaySinh = sinhvien.NgaySinh;

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var existingStudent = students.Find(s => s.Id == id);
            if (existingStudent == null)
                return NotFound();

            return View(existingStudent);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var existingStudent = students.Find(s => s.Id == id);

            if (existingStudent != null)
            {
                students.Remove(existingStudent);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
