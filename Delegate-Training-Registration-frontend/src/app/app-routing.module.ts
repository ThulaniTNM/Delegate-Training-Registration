import { NgModule } from '@angular/core';
import { ExtraOptions, RouterModule, Routes } from '@angular/router';
import { ListCourseComponent } from './course/list-course/list-course.component';
import { DetailCourseComponent } from './course/detail-course/detail-course.component';
import { SingleCourseComponent } from './course/single-course/single-course.component';
import { ListTrainingComponent } from './training/list-training/list-training.component';
import { DelegateTrainingHomeComponent } from './delegate-training-home/delegate-training-home.component';

const routes: Routes =
  [
    { path: "home", component: DelegateTrainingHomeComponent },
    { path: "courses", component: ListCourseComponent },
    {
      path: "courses/:courseCode", component: SingleCourseComponent,
      children: [
        { path: "trainings", component: ListTrainingComponent },
      ]
    },
    { path: "", redirectTo: "/home", pathMatch: "full" },

  ];

const routeOptions: ExtraOptions = {
  paramsInheritanceStrategy: 'always'
}

@NgModule
  ({
    imports: [RouterModule.forRoot(routes, routeOptions)],
    exports: [RouterModule]
  })
export class AppRoutingModule { }
