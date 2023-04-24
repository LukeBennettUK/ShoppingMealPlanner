import {Component, OnInit} from '@angular/core';
import {TestService} from "./services/test.service";
import * as PostsActions from './store/state-actions';
import {select, Store} from "@ngrx/store";
import {errorSelector, isLoadingSelector, postsSelector} from "./store/selectors";
import {Observable} from "rxjs";
import {AppStateInterface} from "./models/state/app-state.interface";
import {PostInterface} from "./models/state/post.interface";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'shopping-meal-planner';
  isLoading$: Observable<boolean>;
  error$: Observable<string | null>;
  posts$: Observable<PostInterface[]>;

  constructor(private testService: TestService, private store: Store<AppStateInterface>) {
      this.isLoading$ = this.store.pipe(select(isLoadingSelector));
      this.error$ = this.store.pipe(select(errorSelector));
      this.posts$ = this.store.pipe(select(postsSelector));
  }

  ngOnInit() {
    // this.testService.getTestData().subscribe(
    //   data => {
    //     console.log('GetTestData: ', data);
    //   }
    // );

    this.store.dispatch(PostsActions.getPosts());
  }
}
