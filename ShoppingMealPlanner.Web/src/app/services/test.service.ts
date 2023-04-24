import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {PostInterface} from "../models/state/post.interface";

@Injectable({
  providedIn: 'root'
})
export class TestService {

  constructor(private http: HttpClient) { }

  getTestData(): Observable<PostInterface[]> {
    return this.http.get<PostInterface[]>('https://localhost:5000/test');
  }
}
