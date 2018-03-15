using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    [Table("AM_Services")]
    public class AM_Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDesc { get; set; }
        //public int AppID { get; set; }
    }
}
