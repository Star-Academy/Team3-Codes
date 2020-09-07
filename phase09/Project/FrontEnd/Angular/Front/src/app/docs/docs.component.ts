import { Component, OnInit, Input } from '@angular/core';
import { Doc } from './models/doc';

@Component({
  selector: 'app-docs',
  templateUrl: './docs.component.html',
  styleUrls: ['./docs.component.scss']
})
export class DocsComponent implements OnInit {
  @Input()
  public docs: Doc[] = [];

  constructor() { }

  ngOnInit(): void {
  }

}
