using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyBepAn.Entities
{
    [Table("roles")]
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Account> Accounts { get; }=new List<Account>();

        public Role()
        {
        }

        public Role(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
