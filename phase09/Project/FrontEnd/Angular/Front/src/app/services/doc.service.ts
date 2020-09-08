import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Doc } from 'src/app/docs/models/doc';

@Injectable()
export class DocService {
  constructor(private http: HttpClient) {
  }

  public async getDocs(searchedString: string): Promise<Doc[]> {
    return new Promise<Doc[]>((resolve) => {
      this.http.post('https://localhost:5001/Search/GetMatchedResult', { Input: searchedString }).subscribe((result: Doc[]) => {
        resolve(result);
      });
    });
  }
}
