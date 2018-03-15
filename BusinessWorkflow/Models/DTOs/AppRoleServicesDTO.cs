using System.Collections.Generic;

namespace BusinessWorkflow.Models.DTOs
{
    public class AppRoleServicesDTO
    {
        public AM_Role Role { get; set; }
        public List<ServiceDTO> Services { get; set; }
    }
}
