//this is the sample template that can be used when calling a businessworkflow api

import { Injectable } from '@angular/core';
import { ClientApiService } from './clientapi.service'; 
import { ClientApiSettings } from './clientapi.settings'; 
import { Users } from '../entities/btam-entities';

@Injectable()
export class UsersService {

  constructor(private api:ClientApiService) {

    //uncomment api.authorizedHeader() if AD Authentication is enabled.
    //use api.normalHeader() if anonymous authentication is enabled.
   
    //api.authorizedHeader();
  }

  getUsers(applicationID:string) {
    this.api.normalHeader();
    this.api.apiUrl=ClientApiSettings.GETBWURL("FEUsers")
    this.api.apiUrl = this.api.apiUrl+"/"+applicationID
    return this.api.getAll();
  }

  postUser(applicationID:string, user: Users) {
    this.api.normalHeader();
    this.api.apiUrl=ClientApiSettings.GETBWURL("FEUsers")
    this.api.apiUrl = this.api.apiUrl+"/"+applicationID
    var body = JSON.stringify(user);
    return this.api.postData(body);
  }

  putUser(userID :string,user: Users) {
    this.api.normalHeader();
    this.api.apiUrl=ClientApiSettings.GETBWURL("FEUsers")
    var body = JSON.stringify(user);
    return this.api.putData(userID,body);
  }

  deleteUser(roleID: string) {
    this.api.normalHeader();
    this.api.apiUrl=ClientApiSettings.GETBWURL("FEUsers")
    return this.api.deleteData(roleID);
  }

}
