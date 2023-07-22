import { Component, Input } from '@angular/core';
import { Training } from 'src/app/models/training';

@Component({
  selector: 'app-detail-training',
  templateUrl: './detail-training.component.html',
  styleUrls: ['./detail-training.component.css']
})
export class DetailTrainingComponent {
  @Input() training: Training;
}
