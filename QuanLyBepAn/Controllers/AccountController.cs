using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyBepAn.Entities;

namespace QuanLyBepAn.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        public AccountController()
        {
        }
        [HttpGet]
        public List<Account> GetAccounts()
        {
            using var context = new ApplicationDbContext();
            List<Account> accounts = context.Accounts.ToList();
            return accounts;
        }
        [HttpGet("{id}")]
        public Account? FindById(int id)
        {
            using var context = new ApplicationDbContext();
            var account = context.Accounts.FirstOrDefault(x => x.Id == id);
            return account;
        }
        [HttpPost]
        public Object Creat(Account account)
        {
            using var context = new ApplicationDbContext();
            context.Accounts.Add(account);
            int v = context.SaveChanges();
            return new {Message = "Inserted", Rows = v};
        }
        [HttpPut]
        public Object Update(Account account)
        {
            using var context = new ApplicationDbContext();
            var a = context.Accounts.FirstOrDefault(x => x.Id == account.Id);
            if (a != null)
            {
                a.Email = account.Email;
                a.DepartmentId = account.DepartmentId;
                a.Name = account.Name;
                a.Password = account.Password;
                int v = context.SaveChanges();
                return new { Message = "Updated", Rows = v };
            }
            return new { Message = "Not found" };
        }
        [HttpDelete("{id}")]
        public Object Delete(int id)
        {
            using var context = new ApplicationDbContext();
            var a = context.Accounts.FirstOrDefault(x => x.Id == id);
            if (a != null)
            {
                a.IsDeleted = true;
                a.DeleteAt = DateTime.Now;
                context.SaveChanges();
                return "Deleted";
            }
            return "Not found";
        }
    }
}
