import { Injectable } from '@angular/core';
import { ClientApiService } from './clientapi.service'; 
import { ClientApiSettings } from './clientapi.settings'; 
import { Roles } from '../entities/btam-entities';

@Injectable()
export class RolesService {

  constructor(
    private api:ClientApiService
  ) { 
  }

  getRoles(applicationID:string) {
    this.api.normalHeader();
    this.api.apiUrl=ClientApiSettings.GETBWURL("FERoles")
    this.api.apiUrl = this.api.apiUrl+"/"+applicationID
    return this.api.getAll();
  }

  postRole(applicationID:string, role: Roles) {
    this.api.normalHeader();
    this.api.apiUrl=ClientApiSettings.GETBWURL("FERoles")
    var body = JSON.stringify(role);
    return this.api.postData(body);
  }

  putRole(roleID:string, role: Roles) {
    this.api.normalHeader();
    this.api.apiUrl=ClientApiSettings.GETBWURL("FERoles")
    var body = JSON.stringify(role);
    return this.api.putData(roleID,body);
  }

}
