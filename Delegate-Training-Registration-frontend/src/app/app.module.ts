import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DetailCourseComponent } from './course/detail-course/detail-course.component';
import { ListCourseComponent } from './course/list-course/list-course.component';
import { DelegateTrainingRegistrationDataService } from './services/delegate-training-registration-data-service.service';
import { SingleCourseComponent } from './course/single-course/single-course.component';
import { ListTrainingComponent } from './training/list-training/list-training.component';

@NgModule
  ({
    declarations:
      [
        AppComponent,
        DetailCourseComponent,
        ListCourseComponent,
        SingleCourseComponent,
        ListTrainingComponent,
      ],
    imports:
      [
        BrowserModule,
        AppRoutingModule
      ],
    providers: [DelegateTrainingRegistrationDataService],
    bootstrap: [AppComponent]
  })
export class AppModule { }
