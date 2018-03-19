﻿namespace BusinessWorkflow.Models.DTOs
{
    public class UserAppRoleDTO
    {
        public int UserAppID { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int Status { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    }
}
