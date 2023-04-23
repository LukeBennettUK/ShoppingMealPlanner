import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {Test} from "../models/test";

@Injectable({
  providedIn: 'root'
})
export class TestService {

  constructor(private http: HttpClient) { }

  getTestData(): Observable<Test> {
    return this.http.get<Test>('https://localhost:5000/test');
  }
}
