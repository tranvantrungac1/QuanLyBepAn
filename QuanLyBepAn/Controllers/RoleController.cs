using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyBepAn.Entities;
namespace QuanLyBepAn.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController
    {
        public RoleController()
        {
        }
        [HttpGet]
        public List<Role> GetRoles()
        {
            using var context = new ApplicationDbContext();
            List<Role> roles = context.Roles.ToList();
            return roles;
        }
        [HttpGet("{id}")]
        public Role? FindById(int id)
        {
            using var context = new ApplicationDbContext();
            var role = context.Roles.FirstOrDefault(x => x.Id == id);
            return role;
        }
        [HttpPost]
        public Object Creat(Role role)
        {
            using var context = new ApplicationDbContext();
            context.Roles.Add(role);
            int v = context.SaveChanges();
            return new { Message = "Inserted", Rows = v };
        }
        [HttpPut]
        public Object Update(Role role)
        {
            using var context = new ApplicationDbContext();
            var d = context.Roles.FirstOrDefault(x => x.Id == role.Id);
            if (d != null)
            {
                d.Name = role.Name;
                int v = context.SaveChanges();
                return new { Message = "Updated", Rows = v };
            }
            return new { Message = "Not found" };
        }
        [HttpDelete("{id}")]
        public Object Delete(int id)
        {
            using var context = new ApplicationDbContext();
            var d = context.Roles.FirstOrDefault(x => x.Id == id);
            if (d != null)
            {
                context.Roles.Remove(d);
                context.SaveChanges();
                return "Deleted";
            }
            return "Not found";
        }
    }
}
