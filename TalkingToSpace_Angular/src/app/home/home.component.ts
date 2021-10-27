import { Component, OnInit, OnDestroy, EventEmitter } from '@angular/core';
import { trigger, transition, state, animate, style,AnimationEvent } from '@angular/animations';
import { AuthService } from '@auth0/auth0-angular';
import {  Router } from '@angular/router';
import { DataService } from "../_services/data.service";


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
          transform: 'scale(10) rotate(70deg)',
          marginLeft: '50%',
          marginRight: '50%',
          marginTop: '20%',
          marginBottom: '50%',
          zIndex: 10
        })
      ),
      transition('initial=>final', animate('2000ms'))

    ]),
  ],
})
export class HomeComponent implements OnInit {


  selectedPlanet:string;
  currentState1 : any;
  currentState2 : any;
  currentState3 : any;
  currentState4 : any;

  constructor(public auth: AuthService,private route: Router) {

    this.selectedPlanet='earth';
    this.currentState1 = 'initial';
    this.currentState2 = 'initial';
    this.currentState3 = 'initial';
    this.currentState4 = 'initial';}

  ngOnInit(): void {

    document.body.style.backgroundImage = "url('./../../../assets/background4.jpg')";
  }


  onAnimationEvent(event: AnimationEvent, status:string) {
    if(status=="done" &&  this.currentState1=="final")
    {
      //this.route.navigate(['/post']);
      this.route.navigate(['post'], {state: { example: 'earth' }});
      this.selectedPlanet='earth';

    }
    if(status=="done" && this.currentState2=="final")
    {
      this.route.navigate(['post'], {state: { example: 'sun' }});
      this.selectedPlanet='sun';
    }
    if(status=="done" && this.currentState3=="final")
    {
      this.route.navigate(['post'], {state: { example: 'moon' }});
      this.selectedPlanet='moon';
    }
    if(status=="done" && this.currentState4=="final")
    {
      this.route.navigate(['post'], {state: { example: 'jupiter' }});
      this.selectedPlanet='jupiter';
    }
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

