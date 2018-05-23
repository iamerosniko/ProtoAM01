
import { Injectable } from '@angular/core';
import { ClientApiService } from './clientapi.service'; 
import { ClientApiSettings } from './clientapi.settings'; 
import { ServiceAttributes } from '../entities/btam-entities';

@Injectable()
export class ServiceAttributesService {

  constructor(private api:ClientApiService) { }

  getAttributes(serviceID:string) {
    this.api.normalHeader();
    this.api.apiUrl=ClientApiSettings.GETBWURL("FEAttributes")+"/"+serviceID;
    return this.api.getAll();
  }

  postAttributes(attribute: ServiceAttributes) {
    this.api.normalHeader();
    this.api.apiUrl=ClientApiSettings.GETBWURL("FEAttributes") 
    var body = JSON.stringify(attribute);
    return this.api.postData(body);
  } 

  putAttributes(attribute: ServiceAttributes) {
    this.api.normalHeader();
    this.api.apiUrl=ClientApiSettings.GETBWURL("FEAttributes") 
    var body = JSON.stringify(attribute);
    return this.api.putData(attribute.ServiceAttributeID.toString(),body );
  }

  deleteAttributes(ServiceAttributeID: string) {
    this.api.normalHeader();
    this.api.apiUrl=ClientApiSettings.GETBWURL("FEAttributes")
    return this.api.deleteData(ServiceAttributeID);
  }
}
