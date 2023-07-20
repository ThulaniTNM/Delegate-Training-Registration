import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DetailCourseComponent } from './course/detail-course/detail-course.component';
import { ListCourseComponent } from './course/list-course/list-course.component';

@NgModule({
  declarations: [
    AppComponent,
    DetailCourseComponent,
    ListCourseComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
