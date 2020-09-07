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
  public value :'';
  // constructor(private router: Router) {}
  
  // this.router.navigate([ 'search-results', query ]);
  ngOnInit(): void {
  }

  public checkForEnter(event: KeyboardEvent) {
    if (event.key === 'Enter') {
      this.searched.emit(this.value);
    }
  }
}


