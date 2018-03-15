using System.Collections.Generic;

namespace BusinessWorkflow.Models.DTOs
{
    public class ServiceDTO
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDesc { get; set; }

        public List<AM_Attribute> Attributes { get; set; }
    }
}
