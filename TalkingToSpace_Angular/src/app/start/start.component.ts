import { Component, OnInit } from '@angular/core';
import { trigger, transition, state, animate, style } from '@angular/animations';


@Component({
  selector: 'app-start',
  templateUrl: './start.component.html',
  styleUrls: ['./start.component.css'],
  animations: [
    trigger('fadeInThenOut1', [
      state('*', style({ opacity: 0 })),
      transition('* => *', [
        animate('1s', style({ opacity: 0 })),
        animate('200ms', style({ opacity: 1 })),
        animate('500ms 3s ease-out', style({ opacity: 0 })),
      ]),
    ]),
    trigger('fadeInThenOut2', [
      state('*', style({ opacity: 0 })),
      transition('* => *', [
        animate('5s', style({ opacity: 0 })),
        animate('200ms', style({ opacity: 1 })),
        animate('500ms 3s ease-out', style({ opacity: 0 })),
      ]),
    ]),
    trigger('fadeInThenOut3', [
      state('*', style({ opacity: 0 })),
      transition('* => *', [
        animate('9s', style({ opacity: 0 })),
        animate('200ms', style({ opacity: 1 })),
        animate('500ms 3s ease-out', style({ opacity: 0 })),
      ]),
    ]),
    trigger('fadeInThenOut4', [
      state('*', style({ opacity: 0 })),
      transition('* => *', [
        animate('13s', style({ opacity: 0 })),
        animate('200ms', style({ opacity: 1 })),
        animate('500ms 4s ease-out', style({ opacity: 0 })),
      ]),
    ]),
    trigger('fadeInThenOut5', [
      state('*', style({ opacity: 0 })),
      transition('* => *', [
        animate('18s', style({ opacity: 0 })),
        animate('200ms', style({ opacity: 1 })),
        animate('500ms 3s ease-out', style({ opacity: 0 })),
      ]),
    ])
  ],

})
export class StartComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {

  }



}
