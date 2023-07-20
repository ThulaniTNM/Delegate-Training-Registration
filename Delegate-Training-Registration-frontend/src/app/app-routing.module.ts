import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListCourseComponent } from './course/list-course/list-course.component';
import { DetailCourseComponent } from './course/detail-course/detail-course.component';
import { SingleCourseComponent } from './course/single-course/single-course.component';

const routes: Routes =
  [
    { path: "courses", component: ListCourseComponent },
    { path: "courses/:courseCode", component: SingleCourseComponent },
  ];

@NgModule
  ({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
export class AppRoutingModule { }
