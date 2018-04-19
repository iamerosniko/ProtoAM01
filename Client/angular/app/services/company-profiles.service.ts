//this is the sample template that can be used when calling a businessworkflow api

import { Injectable } from '@angular/core';
import { ClientApiService } from './clientapi.service'; 
import { ClientApiSettings } from './clientapi.settings'; 
import { CompanyProfiles } from '../entities/btam-entities';
@Injectable()
export class CompanyProfilesService {

  constructor(private api:ClientApiService) {

    //uncomment api.authorizedHeader() if AD Authentication is enabled.
    //use api.normalHeader() if anonymous authentication is enabled.
    api.normalHeader();
    //api.authorizedHeader();
    api.apiUrl=ClientApiSettings.GETBWURL("Users")
  }

  getCompanyProfiles(){
    return this.api.getAll();
  }

  getCompanyProfile(companyProfileID:string){
    return this.api.getOne(companyProfileID);
  }

  postCompanyProfiles(companyProfile:CompanyProfiles){
    var body = JSON.stringify(companyProfile);
    return this.api.postData(body);  
  }

  putCompanyProfiles(companyProfile:CompanyProfiles){
    var body = JSON.stringify(companyProfile);
    return this.api.putData(body,companyProfile.CompanyProfileID.toString());  
  }
}
