import { Component, OnInit, Input } from '@angular/core';
import { Doc } from '../models/doc';

@Component({
  selector: 'app-doc',
  templateUrl: './doc.component.html',
  styleUrls: ['./doc.component.scss']
})
export class DocComponent implements OnInit {

  @Input() doc: Doc;

public hidden = true;

  constructor() { }

  ngOnInit(): void {
  }

}
