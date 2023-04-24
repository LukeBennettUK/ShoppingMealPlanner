import { state } from "@angular/animations";
import { AppStateInterface } from "../models/state/app-state.interface";
import {createSelector} from "@ngrx/store";

export const selectFeature = (state: AppStateInterface) => state.posts;

export const isLoadingSelector = createSelector(
    selectFeature,
    state => state.isLoading
);

export const postsSelector = createSelector(
    selectFeature,
    state => state.posts
);

export const errorSelector = createSelector(
    selectFeature,
    state => state.error
);
