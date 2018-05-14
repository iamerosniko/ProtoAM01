using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("AM_RoleServices")]

    public class AM_RoleServices
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleServiceID { get; set; }
        public int RoleID { get; set; }
        public int ServiceID { get; set; }

    }
}
