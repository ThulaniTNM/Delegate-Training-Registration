import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListCourseComponent } from './course/list-course/list-course.component';
import { DetailCourseComponent } from './course/detail-course/detail-course.component';

const routes: Routes =
  [
    { path: "courses", component: ListCourseComponent },
    { path: "courses/:courseCode", component: DetailCourseComponent },
  ];

@NgModule
  ({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
export class AppRoutingModule { }
