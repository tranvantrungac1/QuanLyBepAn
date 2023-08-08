using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyBepAn.Entities;

namespace QuanLyBepAn.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        public DepartmentController()
        {
        }
        [HttpGet]
        public List<Department> GetDepartments()
        {
            using var context = new ApplicationDbContext();
            List<Department> departments = context.Departments.Include("Accounts").ToList();
            return departments;
        }
        [HttpGet("{id}")]
        public Department? FindById(int id)
        {
            using var context = new ApplicationDbContext();
            var department = context.Departments.Include("Accounts").FirstOrDefault(x => x.Id == id);
            return department;
        }
        [HttpPost]
        public Object Creat(Department department)
        {
            using var context = new ApplicationDbContext();
            context.Departments.Add(department);
            int v = context.SaveChanges();
            return new { Message = "Inserted", Rows = v };
        }
        [HttpPut]
        public Object Update(Department department)
        {
            using var context = new ApplicationDbContext();
            var d = context.Departments.FirstOrDefault(x => x.Id == department.Id);
            if (d != null)
            {
                d.Name = department.Name;
                int v = context.SaveChanges();
                return new { Message = "Updated", Rows = v };
            }
            return new { Message = "Not found" };
        }
        [HttpDelete("{id}")]
        public Object Delete(int id)
        {
            using var context = new ApplicationDbContext();
            var d = context.Departments.FirstOrDefault(x => x.Id == id);
            if (d != null)
            {
                d.IsDeleted = true;
                d.DeletedAt = DateTime.Now;
                context.SaveChanges();
                return "Deleted";
            }
            return "Not found";
        }
    }
}
