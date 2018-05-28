import { Component,OnInit } from '@angular/core';
import { MyHttpResponse } from './services/httpresponse';
import { TreeModel,NodeEvent  } from 'ng2-tree';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  
  public tree: TreeModel = {
    value: 'Programming languages by programming paradigm',
    children: [
      {
        value: 'Object-oriented programming',
        children: [{ value: 'Java' }, { value: 'C++' }, { value: 'C#' }]
      },
      {
        value: 'Prototype-based programming',
        children: [{ value: 'JavaScript' }, { value: 'CoffeeScript' }, { value: 'Lua' }]
      }
    ]
  };
  async ngOnInit(){

  }

  constructor(){
    
  }

  public logEvent(e: NodeEvent): void {
    console.log(e);
  }
}
