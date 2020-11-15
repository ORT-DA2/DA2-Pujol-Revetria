import { Component, Input, OnInit } from '@angular/core';
import { Review } from 'src/app/models/review.model';

@Component({
  selector: 'app-review',
  templateUrl: './review.component.html',
  styleUrls: ['./review.component.scss']
})
export class ReviewComponent implements OnInit {

  @Input() review : Review;


  constructor() { }


  public toArrayScore(){
    let scoreArr : number[] = [];
    let auxScore : number;
    for (auxScore = this.review.score; auxScore > 0; auxScore--) {
      scoreArr.push(1);
    }
    for(let i = scoreArr.length; i<5;i++){
      scoreArr.push(0);
    }
    return scoreArr;
  }

  ngOnInit(): void {
  }

}
