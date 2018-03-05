using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("AM_UserAppServices")]
    public class AM_UserAppService
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserAppServicesID { get; set; }
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public int ServiceID { get; set; }
    }
}
