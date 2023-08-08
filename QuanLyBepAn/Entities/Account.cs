using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyBepAn.Entities
{
    [Table("accounts")]
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Column("email")]
        public string Email { get; set; }
        public string Password { get; set; }
        [Column("departmentId")]
        public int DepartmentId { get; set; }
        [Column("isdeleted")]
        public bool IsDeleted { get; set; }
        [Column("deletedat")]
        public DateTime DeleteAt { get; set; }
        public Department Department { get; set; }
        public List<Role> Roles { get; }= new List<Role>();
        public Account()
        {
        }

        public Account(int id, string name, string email, string password, int departmentId)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            DepartmentId = departmentId;
        }
    }
}
