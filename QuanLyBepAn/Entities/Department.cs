using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyBepAn.Entities
{
    [Table("departments")]
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedAt { get; set; }
        public List<Account>? Accounts { get; } = new List<Account>();
        public Department()
        {
        }

        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
