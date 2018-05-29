using BusinessWorkflow.Models;
using BusinessWorkflow.Models.DTOs;
using BusinessWorkflow.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
        private List<AM_Role> _allRoles;
        private List<AM_InheritedRole> _allInheritedRoles;
        private List<AM_AppRoleService> _allAppRoles;
        private List<AM_Role> _myAppRoles;
        private List<MyInheritedRoles> _myInheritedRoles;
        private List<Treeview> _myTreeViews;

        [HttpGet("{AppID}/{RoleID}")]
        public async Task<List<MyInheritedRoles>> GetRoles([FromRoute]int AppID, [FromRoute]int RoleID)
        {
            _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));
            _myInheritedRoles = new List<MyInheritedRoles>();
            _allInheritedRoles = await _bTAMProviders.inheritedRolesProviders.get();
            _allRoles = await _bTAMProviders.roleProviders.get();
            _allAppRoles = await _bTAMProviders.appRoleServiceProviders.get();

            var approles = _allAppRoles.Where(x => x.AppID == AppID).ToList();
            _myAppRoles = new List<AM_Role>();
            _myInheritedRoles = new List<MyInheritedRoles>();

            foreach (AM_AppRoleService appRole in approles)
            {
                var tempRole = _allRoles.Find(x => x.RoleID == appRole.RoleID);
                if (tempRole != null)
                {
                    _myAppRoles.Add(tempRole);
                }
            }


            try
            {
                foreach (var role in _myAppRoles.Where(x=>x.RoleID== 23))
                {
                    var checkInheritedID = _allInheritedRoles.Find(x => x.MainRoleID == RoleID && x.RoleID == role.RoleID);

                    MyInheritedRoles myInheritedRole = new MyInheritedRoles()
                    {
                        MainRoleID = role.RoleID,
                        RoleName = role.RoleName,
                        IsChecked = RoleID == role.RoleID,
                        InheritedRolesID = checkInheritedID == null ? 0 : checkInheritedID.InheritedRolesID,
                        Trees = new List<Treeview>()
                    };

                    var inheritedRoles = _allInheritedRoles.Where(x => x.MainRoleID == role.RoleID);
                    Treeview Trees = new Treeview();
                    Trees.Children = new List<Treeview>();
                    foreach (var ir in inheritedRoles)
                    {
                        var a = getInheritedData(role,ir.RoleID);
                        myInheritedRole.Trees.Add(a);
                    }
                    //myInheritedRole.Trees.Add(getInheritedData(role));
                    _myInheritedRoles.Add(myInheritedRole);
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            
            return _myInheritedRoles;
        }

        public Treeview getInheritedData(AM_Role mainRole,int roleID)
        {
            var inheritedRole = _allInheritedRoles.Find(x => x.MainRoleID == mainRole.RoleID && x.RoleID== roleID);
            Treeview Trees = new Treeview();
            Trees.Children = new List<Treeview>();
            try
            {
                if(inheritedRole!=null)
                {
                    if(mainRole.RoleName== "Team Leader")
                    {

                    }
                    var roleSearch = _myAppRoles.Find(x => x.RoleID == inheritedRole.RoleID);
                    if (roleSearch != null)
                    {
                        Trees.value = roleSearch.RoleName;
                        var tree = getInheritedData(roleSearch);
                        if(tree.value!=null)
                            Trees.Children.Add( tree);
                    }
                }
                
            }
            catch(Exception ex)
            {
                Console.Write(ex);
            }

            
            return Trees;
        }

        public Treeview getInheritedData(AM_Role mainRole)
        {
            var inheritedRoles = _allInheritedRoles.Where(x => x.MainRoleID == mainRole.RoleID);
            Treeview Trees = new Treeview();
            Trees.Children = new List<Treeview>();
            try
            {
                foreach(var i in inheritedRoles)
                {
                    var roleSearch = _myAppRoles.Find(x => x.RoleID == i.RoleID);
                    if (roleSearch != null)
                    {
                        Trees.value = roleSearch.RoleName;
                        Trees.Children.Add(getInheritedData(roleSearch));
                    }
                }

            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }


            return Trees;
        }
        //public async Task<List<InheritedRolesDTO>> GetRoles([FromRoute]int AppID, [FromRoute]int RoleID)
        //{
        //    _bTAMProviders = new BTAMProviders(HttpContext.Session.GetString("authorizationToken"));

        //    List<AM_InheritedRole> allInheritedroles = await _bTAMProviders.inheritedRolesProviders.get();
        //    List<AM_InheritedRole> inheritedroles = await _bTAMProviders.inheritedRolesProviders.get();
        //    List<AM_InheritedRole> invalidRoles = new List<AM_InheritedRole>();
        //    List<AM_Role> roles = new List<AM_Role>();
        //    List<AM_Role> allRoles = new List<AM_Role>();
        //    List<InheritedRolesDTO> ir = new List<InheritedRolesDTO>();

        //    var userAppServices = await _bTAMProviders.appRoleServiceProviders.get();
        //    var rolesList = await _bTAMProviders.roleProviders.get();

        //    userAppServices = userAppServices.Where(x => x.AppID == AppID).ToList();

        //    foreach (AM_AppRoleService appRoleService in userAppServices)
        //    {
        //        var tempRole = rolesList.Find(x => x.RoleID == appRoleService.RoleID);
        //        //var tempRole = await _bTAMProviders.roleProviders.get(appRoleService.RoleID.ToString());
        //        if (tempRole != null)
        //        {
        //            allRoles.Add(tempRole);
        //        }
        //    }

        //    //1.filter yourself
        //    roles = allRoles.Where(x => x.RoleID != RoleID).ToList();
        //    //getselectedroles
        //    inheritedroles = allInheritedroles.Where(x => x.MainRoleID == RoleID).ToList();
        //    invalidRoles = allInheritedroles.Where(x => x.RoleID == RoleID).ToList();

        //    //foreach (var inheritedRole in invalidRoles)
        //    //{
        //    //    roles = roles.Where(x => x.RoleID != inheritedRole.MainRoleID).ToList();
        //    //}

        //    //gets selected inheritedrole
        //    foreach (var inheritedRole in inheritedroles)
        //    {
        //        var role = allRoles.Find(x => x.RoleID == inheritedRole.RoleID);
        //        if (role != null)
        //        {
        //            ir.Add(new InheritedRolesDTO
        //            {
        //                InheritedRolesID = inheritedRole.InheritedRolesID,
        //                MainRoleID = inheritedRole.MainRoleID,
        //                IsChecked = true,
        //                RoleID = role.RoleID,
        //                RoleName = role.RoleName
        //            });
        //            roles = roles.Where(x => x.RoleID != role.RoleID).ToList();
        //        }
        //    }

        //    foreach (var role in roles)
        //    {
        //        ir.Add(new InheritedRolesDTO
        //        {
        //            MainRoleID = RoleID,
        //            RoleID = role.RoleID,
        //            RoleName = role.RoleName
        //        });
        //    }

        //    //filter ir if there's a inherited part
        //    var irItems = new List<InheritedRolesDTO>();
        //    foreach (var irItem in ir)
        //    {
        //        inheritedroles = allInheritedroles.Where(x => x.MainRoleID == irItem.RoleID).ToList();
        //        foreach (var inheritedRolesItem in inheritedroles)
        //        {
        //            irItems = irItems.Concat(ir.Where(x => x.RoleID != inheritedRolesItem.RoleID).ToList()).ToList();
        //        }
        //    }

        //    return irItems.Count() == 0 ? ir : irItems.Distinct().ToList();
        //}

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