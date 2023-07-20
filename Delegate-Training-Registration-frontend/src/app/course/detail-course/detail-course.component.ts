import { Component, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Course } from 'src/app/models/course';
import { DelegateTrainingRegistrationDataService } from 'src/app/services/delegate-training-registration-data-service.service';

@Component({
  selector: 'app-detail-course',
  templateUrl: './detail-course.component.html',
  styleUrls: ['./detail-course.component.css']
})
export class DetailCourseComponent {
  @Input() course: Course | undefined = undefined;

  constructor(private router: Router, private route: ActivatedRoute, private delegateDataService: DelegateTrainingRegistrationDataService) {
  }


  viewCourse(): void {
    this.router.navigate(["courses", this.course?.CourseCode]);
  }
}
