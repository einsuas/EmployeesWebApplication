import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfirmViewComponent } from './confirm_view.component';

describe('ConfirmViewComponent', () => {
  let component: ConfirmViewComponent;
  let fixture: ComponentFixture<ConfirmViewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConfirmViewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConfirmViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});
