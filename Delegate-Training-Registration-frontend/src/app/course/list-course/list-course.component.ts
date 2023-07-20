import { Course } from 'src/app/models/course';
import { DelegateTrainingRegistrationDataService } from './../../services/delegate-training-registration-data-service.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-list-course',
  templateUrl: './list-course.component.html',
  styleUrls: ['./list-course.component.css']
})
export class ListCourseComponent implements OnInit {
  courses: Course[] = [];
  constructor(private delegateDataService: DelegateTrainingRegistrationDataService) { }

  ngOnInit(): void {
    this.courses = this.delegateDataService.getCourses();
  }
}
