import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Course } from 'src/app/models/course';
import { DelegateTrainingRegistrationDataService } from 'src/app/services/delegate-training-registration-data-service.service';

@Component({
  selector: 'app-single-course',
  templateUrl: './single-course.component.html',
  styleUrls: ['./single-course.component.css']
})
export class SingleCourseComponent implements OnInit {
  course: Course | undefined;
  constructor(private router: Router, private route: ActivatedRoute, private delegateDataService: DelegateTrainingRegistrationDataService) { }

  ngOnInit(): void {
    const courseCode = this.route.snapshot.paramMap.get("courseCode");
    this.course = this.delegateDataService.getCourse(courseCode!);
  }

  courseList(): void {
    this.router.navigate(["courses"]);

  }
}
