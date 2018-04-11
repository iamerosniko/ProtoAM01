using System;

namespace BusinessWorkflow.Models
{
    public class AppToken
    {
        public String TokenName { get; set; }
        public String Token { get; set; }
        public AppToken()
        {
            Token = "";
            TokenName = "";
        }
    }
}
