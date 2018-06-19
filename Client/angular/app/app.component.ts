import { Component,OnInit } from '@angular/core';
import { MyHttpResponse } from './services/httpresponse';
import { EnvironmentSvc } from './services/environments.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  
  async ngOnInit(){
    var BW =await this.environmentSvc.getBWURL();
    localStorage.setItem("BWAPI",BW.URL)
  }

  constructor(private environmentSvc:EnvironmentSvc){
    
  }
}
