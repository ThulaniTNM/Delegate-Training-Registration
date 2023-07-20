import { Injectable } from '@angular/core';
import { Course } from '../models/course';

@Injectable({
  providedIn: 'root'
})
export class DelegateTrainingRegistrationDataService {

  // local data
  courses: Course[] = [
    { CourseCode: "e288a507-bb38-477e-b985-c7afd1ee8057", CourseName: "Computer science", CourseDescription: "Software & hardware" },
    { CourseCode: "7aaa6300-d539-45de-b0a1-2f4d5750f75b", CourseName: "Mathematics", CourseDescription: "Numbers & operators" },
    { CourseCode: "7aaa6300-d539-45de-b0a1-2f4d5750f75b", CourseName: "Mathematics", CourseDescription: "Numbers & operators" },
    { CourseCode: "7aaa6300-d539-45de-b0a1-2f4d5750f75b", CourseName: "Mathematics", CourseDescription: "Numbers & operators" },
    { CourseCode: "7aaa6300-d539-45de-b0a1-2f4d5750f75b", CourseName: "Mathematics", CourseDescription: "Numbers & operators" },
  ];
  constructor() { }

  public getCourses(): Course[] {
    return this.courses;
  }

  public getCourse(courseCode: string): Course {
    return this.courses.find(c => c.CourseCode === courseCode)!;
  }
}
