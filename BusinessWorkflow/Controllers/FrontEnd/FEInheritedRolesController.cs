using BusinessWorkflow.Models;
using BusinessWorkflow.Models.DTOs;
using BusinessWorkflow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessWorkflow.Controllers.FrontEnd
{
    [Produces("application/json")]
    [Route("api/FEInheritedRoles")]
    public class FEInheritedRolesController : Controller
    {
        private BTAMProviders _bTAMProviders;

        [HttpGet("{AppID}/{RoleID}")]
        public async Task<List<InheritedRolesDTO>> GetRoles([FromRoute]int AppID, [FromRoute]int RoleID)
        {
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));

            List<AM_InheritedRole> allInheritedroles = await _bTAMProviders.inheritedRolesProviders.get();
            List<AM_InheritedRole> inheritedroles = await _bTAMProviders.inheritedRolesProviders.get();
            List<AM_InheritedRole> invalidRoles = new List<AM_InheritedRole>();
            List<AM_Role> roles = new List<AM_Role>();
            List<AM_Role> allRoles = new List<AM_Role>();
            List<InheritedRolesDTO> ir = new List<InheritedRolesDTO>();

            var userAppServices = await _bTAMProviders.appRoleServiceProviders.get();
            userAppServices = userAppServices.Where(x => x.AppID == AppID).ToList();

            foreach (AM_AppRoleService appRoleService in userAppServices)
            {
                var tempRole = await _bTAMProviders.roleProviders.get(appRoleService.RoleID.ToString());
                if (tempRole != null)
                {
                    allRoles.Add(tempRole);
                }
            }

            //1.filter yourself
            roles = allRoles.Where(x => x.RoleID != RoleID).ToList();
            //getselectedroles
            inheritedroles = allInheritedroles.Where(x => x.MainRoleID == RoleID).ToList();
            invalidRoles = allInheritedroles.Where(x => x.RoleID == RoleID).ToList();

            foreach (var inheritedRole in invalidRoles)
            {
                roles = roles.Where(x => x.RoleID != inheritedRole.MainRoleID).ToList();
            }

            //gets selected inheritedrole
            foreach (var inheritedRole in inheritedroles)
            {
                var role = allRoles.Find(x => x.RoleID == inheritedRole.RoleID);
                if (role != null)
                {
                    ir.Add(new InheritedRolesDTO
                    {
                        InheritedRolesID = inheritedRole.InheritedRolesID,
                        MainRoleID = inheritedRole.MainRoleID,
                        IsChecked = true,
                        RoleID = role.RoleID,
                        RoleName = role.RoleName
                    });
                    roles = roles.Where(x => x.RoleID != role.RoleID).ToList();
                }
                //ir.Add
            }

            foreach (var role in roles)
            {
                ir.Add(new InheritedRolesDTO
                {
                    MainRoleID = RoleID,
                    RoleID = role.RoleID,
                    RoleName = role.RoleName
                });
            }

            return ir;
        }
        [HttpPost]
        public async Task<AM_InheritedRole> postInheritedRole([FromBody] AM_InheritedRole inheritedRole)
        {
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));
            return await _bTAMProviders.inheritedRolesProviders.Post(inheritedRole);
        }
        [HttpDelete("{InheritedRoleID}")]
        public async Task<AM_InheritedRole> deleteInheritedRole([FromRoute] string InheritedRoleID)
        {
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));
            return await _bTAMProviders.inheritedRolesProviders.Delete(InheritedRoleID);
        }
    }
}