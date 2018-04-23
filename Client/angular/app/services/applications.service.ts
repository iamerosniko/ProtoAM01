//this is the sample template that can be used when calling a businessworkflow api

import { Injectable } from '@angular/core';
import { ClientApiService } from './clientapi.service'; 
import { ClientApiSettings } from './clientapi.settings'; 
import { Applications } from '../entities/btam-entities';

const apps: Applications[] = [
    {AppID: "abc", AppName: "test", AppMemberName: "test member"}, 
    {AppID: "def", AppName: "biztech d", AppMemberName: "Biztech"}
]

@Injectable()
export class ApplicationsService {

  constructor(private api:ClientApiService) {

    //uncomment api.authorizedHeader() if AD Authentication is enabled.
    //use api.normalHeader() if anonymous authentication is enabled.
    //api.authorizedHeader();
    
  }

  getApplications() {
    this.api.normalHeader();
    this.api.apiUrl=ClientApiSettings.GETBWURL("FEApplications")
    return this.api.getAll();
    
    // return apps;
  }

  getApplication(applicationID: string) {
    this.api.normalHeader();
    this.api.apiUrl=ClientApiSettings.GETBWURL("FEApplications")
    return this.api.getOne(applicationID);
      
    //return apps.find(app => app.AppID === applicationID);
  }

  postApplication(application: Applications) {
    this.api.normalHeader();
    this.api.apiUrl=ClientApiSettings.GETBWURL("FEApplications")
    var body = JSON.stringify(application);
    return this.api.postData(body);
  } 

  putApplication(application: Applications) {
    this.api.normalHeader();
    this.api.apiUrl=ClientApiSettings.GETBWURL("FEApplications")
    var body = JSON.stringify(application);
    return this.api.putData(application.AppID.toString(),body );
  }

  deleteApplication(applicationID: string) {
    this.api.normalHeader();
    this.api.apiUrl=ClientApiSettings.GETBWURL("FEApplications")
    return this.api.deleteData(applicationID);
  }
}
