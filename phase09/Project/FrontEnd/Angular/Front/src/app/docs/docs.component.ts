import { Component, OnInit, Input } from '@angular/core';
import { Doc } from './models/doc';

@Component({
  selector: 'app-docs',
  templateUrl: './docs.component.html',
  styleUrls: ['./docs.component.scss']
})
export class DocsComponent implements OnInit {
  @Input()
  public docs: Doc[] = [
    { "name": "name1", "content": "salam javan irani" },
    { "name": "name2", "content": "man ye parandam . arezoo daram" },
    { "name": "name3", "content": "donya hame hich o ahl donya hame hich" },
    { "name": "name4", "content": "miazar moori ke dane kesh ast" },
    { "name": "name5", "content": "tan adami sharif ast be jan adamiat ? na:/ . hamin lebas zibast neshan adamiat" },
  ];



  constructor() { }

  ngOnInit(): void {
    console.log(this.docs);
  }

}
