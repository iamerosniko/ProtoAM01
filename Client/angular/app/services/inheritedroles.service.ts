import { Injectable } from '@angular/core';
import { ClientApiService } from './clientapi.service'; 
import { ClientApiSettings } from './clientapi.settings'; 
import { InheritedRoles } from '../entities/btam-entities';

@Injectable()
export class InheritedRolesService {

  constructor(
    private api:ClientApiService
  ) { 
  }

  getRoles(applicationID:string,roleID:string) {
    this.api.normalHeader();
    this.api.apiUrl=ClientApiSettings.GETBWURL("FEInheritedRoles")
    this.api.apiUrl = this.api.apiUrl+"/"+applicationID+"/"+roleID
    return this.api.getAll();
  }

  postInheritedRole(inheritedRole:InheritedRoles) {
    this.api.normalHeader();
    this.api.apiUrl=ClientApiSettings.GETBWURL("FEInheritedRoles")
    this.api.apiUrl = this.api.apiUrl
    
    var body = JSON.stringify(inheritedRole);
    return this.api.postData(body);
  }

  // putRole(roleID:string, role: Roles) {
  //   this.api.normalHeader();
  //   this.api.apiUrl=ClientApiSettings.GETBWURL("FERoles")
  //   var body = JSON.stringify(role);
  //   return this.api.putData(roleID,body);
  // }

  deleteInheritedRole(inheritedRoleID: string) {
    this.api.normalHeader();
    this.api.apiUrl=ClientApiSettings.GETBWURL("FEInheritedRoles")
    return this.api.deleteData(inheritedRoleID);
  }

}
