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
        public int ServiceID { get; set; }
        public int AttribID { get; set; }
    }
}
