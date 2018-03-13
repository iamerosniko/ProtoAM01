using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("AM_InheritedRoles")]
    public class AM_InheritedRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InheritedRolesID { get; set; }
        //FK AppRoleServices
        public int RoleID { get; set; }
    }
}
