import {Injectable} from "@angular/core";
import {Actions, createEffect, ofType} from "@ngrx/effects";
import * as PostsActions from './state-actions';
import {catchError, map, mergeMap, of} from "rxjs";
import {TestService} from "../services/test.service";

@Injectable()
export class PostsEffects {
    getPosts$ = createEffect(() =>
        this.actions$.pipe(
            ofType(PostsActions.getPosts),
            mergeMap(() => {
                return this.testService
                    .getTestData()
                    .pipe(
                        map(posts => PostsActions.getPostsSuccess({ posts })),
                        catchError(error =>
                            of(PostsActions.getPostsFailure({ error: error.message }))));
        }))
    );

    constructor(private actions$: Actions, private testService: TestService) {
    }
}
