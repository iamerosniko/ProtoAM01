import { Injectable } from '@angular/core';
import { ClientApiService } from './clientapi.service'; 
import { ClientApiSettings } from './clientapi.settings'; 
import { UserRoles } from '../entities/btam-entities';

@Injectable()
export class RoleUsersService {

  constructor(
    private api:ClientApiService
  ) { 

  }

  postRole(userrole: UserRoles) {
    this.api.normalHeader();
    this.api.apiUrl=ClientApiSettings.GETBWURL("FERolesToUsers")
    this.api.apiUrl = this.api.apiUrl
    
    var body = JSON.stringify(userrole);
    return this.api.postData(body);
  }

}
