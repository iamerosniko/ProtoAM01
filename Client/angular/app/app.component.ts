import { Component,OnInit } from '@angular/core';
import { CompanyProfilesService } from './services/client.services';
import { MyHttpResponse } from './services/httpresponse';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  
  resp: MyHttpResponse;
  a:any;
  async ngOnInit(){
  //   this.get();
   this.resp=await this.api.getCompanyProfiles();
   this.a=await this.api.getCompanyProfile("2");
  }

  constructor(private api : CompanyProfilesService){
    
  }
}
