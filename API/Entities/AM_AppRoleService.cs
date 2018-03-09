using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{

    [Table("AM_AppRoleServices")]
    public class AM_AppRoleService
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppRoleID { get; set; }
        public int AppID { get; set; }
        public int RoleID { get; set; }
        public int ServiceID { get; set; }
    }
}
