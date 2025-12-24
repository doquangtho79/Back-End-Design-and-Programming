using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        // Giả lập dữ liệu lưu tạm (vì chưa dùng database)
        private static List<Employee> _employees = new List<Employee>
    {
        new Employee { Id = 1, Name = "Thơ", Position = "Nhân viên", Age = 30, Email = "thodq@example.com" },
        new Employee { Id = 2, Name = "Công", Position = "Lãnh đạo", Age = 25, Email = "congtd@example.com" }
    };

        // GET: /Employee
        [HttpGet]
        public IActionResult Index()
        {
            return View(_employees); // Read
        }

        // GET: /Employee/Details/1
        [HttpGet]
        public IActionResult Details(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null) return NotFound();
            return View(employee);
        }

        // GET: /Employee/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View(); // Hiển thị form thêm mới
        }

        // POST: /Employee/Create
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.Id = _employees.Max(e => e.Id) + 1;
                _employees.Add(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: /Employee/Edit/1
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null) return NotFound();
            return View(employee);
        }

        // POST: /Employee/Edit/1
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var existing = _employees.FirstOrDefault(e => e.Id == employee.Id);
                if (existing == null) return NotFound();

                existing.Name = employee.Name;
                existing.Position = employee.Position;
                existing.Age = employee.Age;
                existing.Email = employee.Email;

                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: /Employee/Delete/1
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null) return NotFound();
            return View(employee);
        }

        // POST: /Employee/DeleteConfirmed/1
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
            return RedirectToAction("Index");
        }
    }
    
}
