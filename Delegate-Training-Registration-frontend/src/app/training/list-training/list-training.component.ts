import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Training } from 'src/app/models/training';
import { DelegateTrainingRegistrationDataService } from 'src/app/services/delegate-training-registration-data-service.service';

@Component({
  selector: 'app-list-training',
  templateUrl: './list-training.component.html',
  styleUrls: ['./list-training.component.css']
})
export class ListTrainingComponent implements OnInit {
  trainings: Training[];

  constructor(private trainingDataService: DelegateTrainingRegistrationDataService, private route: ActivatedRoute) { }
  ngOnInit(): void {
    const courseCode: string = this.route.snapshot.paramMap.get("courseCode")!;
    this.trainings = this.trainingDataService.getTrainings(courseCode);
  }

}
