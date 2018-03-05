using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{

    [Table("AM_Attributes")]
    public class AM_Attribute
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttribID { get; set; }
        public string AttribName { get; set; }
        public string AttribDesc { get; set; }
    }
}
