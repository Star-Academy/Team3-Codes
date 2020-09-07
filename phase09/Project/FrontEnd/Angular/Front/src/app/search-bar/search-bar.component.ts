import { Component, OnInit, EventEmitter, Output } from '@angular/core';

// import { Router } from'@angular/router';


@Component({
  selector: 'app-search-bar',
  templateUrl: './search-bar.component.html',
  styleUrls: ['./search-bar.component.scss']
})
export class SearchBarComponent implements OnInit {

    @Output()
    public searched = new EventEmitter<string>();
  
    public value = '';
  
    constructor() { }
  
    ngOnInit(): void {
    }
  
    public checkForEnter(event: KeyboardEvent) {
      if (event.key === 'Enter') {
        console.log(this.value);
        this.searched.emit(this.value);
      }
    }
  
  }

