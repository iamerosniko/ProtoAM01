using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("AM_ServiceAttributes")]
    public class AM_ServiceAttribute
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceAttributeID { get; set; }
        public int RoleServiceID { get; set; }
        public string AttribName { get; set; }
        public string AttribDesc { get; set; }
    }
}
