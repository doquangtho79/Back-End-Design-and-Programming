using EmployeeManagement.Models;

namespace EmployeeManagement.Services
{
    public class EmployeeService : IEmployeeService
    {
        // Lưu trữ tạm trên bộ nhớ
        private List<Employee> _employees;

        public EmployeeService()
        {
            // Khởi tạo dữ liệu mẫu
            _employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Thơ", Position = "Nhân viên", Age = 30, Email = "thodq@example.com" },
            new Employee { Id = 2, Name = "Công", Position = "Lãnh đạo", Age = 25, Email = "congtd@example.com" }
        };
        }

        public List<Employee> GetAll()
        {
            return _employees;
        }

        public Employee? GetById(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }

        public void Add(Employee employee)
        {

            employee.Id = _employees.Any()? _employees.Max(e => e.Id) + 1 : 1;
            _employees.Add(employee);
        }

        public void Update(Employee employee)
        {
            var existing = GetById(employee.Id);
            if (existing != null)
            {
                existing.Name = employee.Name;
                existing.Position = employee.Position;
                existing.Age = employee.Age;
                existing.Email = employee.Email;
            }
        }

        public void Delete(int id)
        {
            var employee = GetById(id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
        }

    }
}



