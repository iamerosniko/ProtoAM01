using System.Collections.Generic;

namespace BusinessWorkflow.Models.DTOs
{
    public class Treeview
    {
        public string value { get; set; }
        public List<Treeview> children { get; set; }
    }
}
