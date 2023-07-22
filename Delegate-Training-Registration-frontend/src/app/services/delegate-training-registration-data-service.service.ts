import { Injectable } from '@angular/core';
import { Course } from '../models/course';
import { Training } from '../models/training';

@Injectable({
  providedIn: 'root'
})
export class DelegateTrainingRegistrationDataService {

  // local data
  courses: Course[] =
    [
      { CourseCode: "e288a507-bb38-477e-b985-c7afd1ee8057", CourseName: "Computer science", CourseDescription: "Software & hardware" },
      { CourseCode: "7aaa6300-d539-45de-b0a1-2f4d5750f75b", CourseName: "Mathematics", CourseDescription: "Numbers & operators" }
    ];

  training: Training[] =
    [
      { TrainingId: "7c45fd03-f621-418d-92b5-541364f13e97", TrainingName: "CSC101", TrainingVenue: "Lab Center", TrainingCost: 299.33, TrainingDate: new Date(), TrainingRegistrationClosingDate: new Date(), AvailableSeats: 10, CourseCode: "e288a507-bb38-477e-b985-c7afd1ee8057" },
      { TrainingId: "eb0551e1-87ff-4e9e-8806-8be3b2413674", TrainingName: "MTM101", TrainingVenue: "Accounting Center", TrainingCost: 599.33, TrainingDate: new Date(), TrainingRegistrationClosingDate: new Date(), AvailableSeats: 20, CourseCode: "7aaa6300-d539-45de-b0a1-2f4d5750f75b" }
    ]

  constructor() { }

  public getCourses(): Course[] {
    return this.courses;
  }

  public getCourse(courseCode: string): Course {
    return this.courses.find(c => c.CourseCode === courseCode)!;
  }

  public getTrainings(courseCode: string): Training[] {
    return this.training.filter(t => t.CourseCode === courseCode);
  }

  public getTraining(courseCode: string, trainingId: string): Training {
    return this.training.find(t => t.CourseCode === courseCode && t.TrainingId === trainingId)!;
  }
}
