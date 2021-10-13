import { Component, OnInit } from '@angular/core';
import { trigger, transition, state, animate, style,useAnimation } from '@angular/animations';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  animations: [
    trigger('balloonEffect', [
      state(
        'initial',
        style({
          transform: 'scale(1)',
        })
      ),
      state(
        'final',
        style({
          transform: 'scale(20)',
          marginLeft: '50%',
          marginRight: '50%',
          marginTop: '20%',
          marginBottom: '50%',
        })
      ),
      transition('final=>initial', animate('1000ms')),
      transition('initial=>final', animate('1500ms')),
    ]),
  ],
})
export class HomeComponent implements OnInit {

  currentState1 : any;
  currentState2 : any;
  currentState3 : any;
  currentState4 : any;

  constructor() {
    this.currentState1 = 'initial';
    this.currentState2 = 'initial';
    this.currentState3 = 'initial';
    this.currentState4 = 'initial';}

  ngOnInit(): void {
  }


  changeStateplanet1() {
    if (
      this.currentState2 == 'initial' &&
      this.currentState3 == 'initial' &&
      this.currentState4 == 'initial'
    ) {
      this.currentState1 =
        this.currentState1 === 'initial' ? 'final' : 'initial';
    }
  }
  changeStateplanet2() {
    if (
      this.currentState1 == 'initial' &&
      this.currentState3 == 'initial' &&
      this.currentState4 == 'initial'
    ) {
      this.currentState2 =
        this.currentState2 === 'initial' ? 'final' : 'initial';
    }
  }
  changeStateplanet3() {
    if (
      this.currentState1 == 'initial' &&
      this.currentState2 == 'initial' &&
      this.currentState4 == 'initial'
    ) {
      this.currentState3 =
        this.currentState3 === 'initial' ? 'final' : 'initial';
    }
  }
  changeStateplanet4() {
    if (
      this.currentState1 == 'initial' &&
      this.currentState2 == 'initial' &&
      this.currentState3 == 'initial'
    ) {
      this.currentState4 =
        this.currentState4 === 'initial' ? 'final' : 'initial';
    }
  }
}

