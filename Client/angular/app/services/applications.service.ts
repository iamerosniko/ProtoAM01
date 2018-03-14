//this is the sample template that can be used when calling a businessworkflow api

import { Injectable } from '@angular/core';
import { ClientApiService } from './clientapi.service'; 
import { ClientApiSettings } from './clientapi.settings'; 
import { Applications } from '../entities/btam-entities';
@Injectable()
export class ApplicationsService {

  constructor(private api:ClientApiService) {

    //uncomment api.authorizedHeader() if AD Authentication is enabled.
    //use api.normalHeader() if anonymous authentication is enabled.
    api.normalHeader();
    //api.authorizedHeader();
    api.apiUrl=ClientApiSettings.GETAPIURL("Applications")
  }

  //getCompanyProfiles(){
  //  return this.api.getAll();
  //}

  //getCompanyProfile(companyProfileID:string){
  //  return this.api.getOne(companyProfileID);
  //}

  //postCompanyProfiles(companyProfile:Applications){
  //  var body = JSON.stringify(companyProfile);
  //  return this.api.postData(body);  
  //}

  //putCompanyProfiles(companyProfile:Applications){
  //  var body = JSON.stringify(companyProfile);
  //  return this.api.putData(body,companyProfile.AppID.toString());  
  //}

  getApplications() {
      return this.api.getAll();
  }

  getApplication(applicationID: string) {
      return this.api.getOne(applicationID);
  }

  postApplication(application: Applications) {
      var body = JSON.stringify(application);
      return this.api.postData(body);
  }

  putApplication(application: Applications) {
      var body = JSON.stringify(application);
      return this.api.putData(body, application.AppID.toString());
  }

  deleteApplication(applicationID: string) {
      return this.api.deleteData(applicationID);
  }
}
