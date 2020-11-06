import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-confirm_view',
  templateUrl: './confirm_view.component.html',
  styleUrls: ['./confirm_view.component.css']
})
export class ConfirmViewComponent implements OnInit {

  constructor() { }

  @Input() answer: boolean;
  @Output() answerChange: EventEmitter<boolean> = new EventEmitter<boolean>();
  @Input() message: string;
  @Input() visible: boolean;
  @Output() visibleChange: EventEmitter<boolean> = new EventEmitter<boolean>();

  ngOnInit() 
  {
  }

  confirm(answer: boolean) 
  {
    this.answer = answer;
    this.answerChange.emit(this.answer);
    this.visible = false;       
    this.visibleChange.emit(this.visible);
  }

}
