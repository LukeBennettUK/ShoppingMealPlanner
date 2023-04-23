import {Component, OnInit} from '@angular/core';
import {TestService} from "./services/test.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'shopping-meal-planner';

  constructor(private testService: TestService) {
  }

  ngOnInit() {
    this.testService.getTestData().subscribe(
      data => {
        console.log('GetTestData: ', data);
      }
    );
  }
}
