import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Course } from 'src/app/models/course';
import { DelegateTrainingRegistrationDataService } from 'src/app/services/delegate-training-registration-data-service.service';

@Component({
  selector: 'app-detail-course',
  templateUrl: './detail-course.component.html',
  styleUrls: ['./detail-course.component.css']
})
export class DetailCourseComponent implements OnInit {
  @Input() course: Course | undefined = undefined;
  hasCode: boolean | undefined;
  constructor(private router: Router, private route: ActivatedRoute, private delegateDataService: DelegateTrainingRegistrationDataService) {
  }

  ngOnInit(): void {
    this.hasCode = !!this.route.snapshot.paramMap.get("codeExist");
    if (this.hasCode) {
      const courseCode = this.route.snapshot.paramMap.get("courseCode");
      this.course = this.delegateDataService.getCourse(courseCode!);
    }
  }

  courseList(): void {
    this.router.navigate(["courses"]);

  }

  viewCourse(): void {
    this.hasCode = true;
    this.router.navigate(["courses", this.course?.CourseCode, { codeExist: this.hasCode }]);
  }
}
