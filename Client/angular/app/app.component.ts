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
  async ngOnInit(){
  //   this.get();
   this.resp=<MyHttpResponse>await this.api.getCompanyProfiles();
   var a = (await this.api.getCompanyProfiles()).Value;
   console.log(this.resp.Value);
  }

  constructor(private api : CompanyProfilesService){
    
  }
}
