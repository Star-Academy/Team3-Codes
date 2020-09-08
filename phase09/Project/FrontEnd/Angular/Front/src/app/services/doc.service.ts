import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Doc } from 'src/app/docs/models/doc';

@Injectable()
export class DocService {
  constructor(private http: HttpClient) {
  }

  public async getTours(searchkey: string): Promise<Doc[]> {
    return new Promise<Doc[]>((resolve) => {
      this.http.post('https://localhost:44386/api/tour/search', { city: searchkey }).subscribe((result: Tour[]) => {
        resolve(result);
      });
    });
  }
}
