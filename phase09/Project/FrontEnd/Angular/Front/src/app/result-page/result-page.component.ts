import { Component, OnInit } from '@angular/core';
import { DocsComponent } from '../docs/docs.component';
import { Doc } from '../docs/models/doc';

@Component({
  selector: 'app-result-page',
  templateUrl: './result-page.component.html',
  styleUrls: ['./result-page.component.scss']
})
export class ResultPageComponent implements OnInit {
  public docs: Doc[]=[ { "name": "name11111", "content": "salam javan irani" },
  { "name": "name2", "content": "man ye parandam . arezoo daram" },
  { "name": "name3", "content": "donya hame hich o ahl donya hame hich" },
  { "name": "name4", "content": "miazar moori ke dane kesh ast" },
  { "name": "name5", "content": "tan adami sharif ast be jan adamiat ? na:/ . hamin lebas zibast neshan adamiat" },];
  constructor() { }

  ngOnInit(): void {

  }

}
