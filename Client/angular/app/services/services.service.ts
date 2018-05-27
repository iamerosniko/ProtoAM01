
import { Injectable } from '@angular/core';
import { ClientApiService } from './clientapi.service'; 
import { ClientApiSettings } from './clientapi.settings'; 
import { Services } from '../entities/btam-entities';

@Injectable()
export class ServicesService {

  constructor(private api:ClientApiService) { }

  getServices() {
    this.api.normalHeader();
    this.api.apiUrl=ClientApiSettings.GETBWURL("FEServices")
    return this.api.getAll();
  }

  getService(roleID: string) {
    this.api.normalHeader();
    this.api.apiUrl=ClientApiSettings.GETBWURL("FEServices")
    return this.api.getOne(roleID);
  }

  postService(service: Services) {
    this.api.normalHeader();
    this.api.apiUrl=ClientApiSettings.GETBWURL("FEServices") 
    var body = JSON.stringify(service);
    return this.api.postData(body);
  } 

  putService(service: Services) {
    this.api.normalHeader();
    this.api.apiUrl=ClientApiSettings.GETBWURL("FEServices") 
    var body = JSON.stringify(service);
    return this.api.putData(service.RoleServiceID.toString(),body );
  }

  deleteService(serviceID: string) {
    this.api.normalHeader();
    this.api.apiUrl=ClientApiSettings.GETBWURL("FEServices")
    return this.api.deleteData(serviceID);
  }
}
