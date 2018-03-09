using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{

    [Table("AM_UserAppRoleServices")]
    public class AM_UserAppRoleService
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserAppRoleServiceID { get; set; }
        //FK UserApps
        public int UserAppID { get; set; }
        //FK AppRoleServices
        public int AppRoleServiceID { get; set; }
    }
}
