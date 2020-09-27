import { Component, OnInit } from '@angular/core';
import { Doc } from '../docs/models/doc';
import { DocService } from '../services/doc.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-result-page',
  templateUrl: './result-page.component.html',
  styleUrls: ['./result-page.component.scss']
})
export class ResultPageComponent implements OnInit {
  public docs: Doc[]=[];

  constructor(private service: DocService ,private router: Router,
    private route: ActivatedRoute) { }

  async ngOnInit() {
  let searchedInput ;
  this.route.queryParams.subscribe(params => {
      searchedInput = params['input']})
      console.log(searchedInput);
  this.searchDoc(searchedInput) ;
  }
  public async searchDoc(input: string) {
    this.docs = await this.service.getDocs(input);
  }
  public navigateToResultPageRoute(input :string){
    this.router.navigate(['/result'], { queryParams: { input: input } });
  }

}
