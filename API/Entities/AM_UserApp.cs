using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{

    [Table("AM_UserApps")]
    public class AM_UserApp
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserAppID { get; set; }
        public int UserID { get; set; }
        public int AppID { get; set; }
    }
}
