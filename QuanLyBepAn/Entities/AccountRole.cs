using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyBepAn.Entities
{
    [Table("accountRoles")]
    public class AccountRole
    {
        public int Id { get; set; }
        [Column("roleId")]
        public int RoleId { get; set; }
        [Column("accountId")]
        public int AccountId { get; set; }

        public AccountRole()
        {
        }

        public AccountRole(int id, int roleId, int accountId)
        {
            Id = id;
            RoleId = roleId;
            AccountId = accountId;
        }
    }
}
