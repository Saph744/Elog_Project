import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LeavesettingComponent } from './leavesetting.component';

describe('LeavesettingComponent', () => {
  let component: LeavesettingComponent;
  let fixture: ComponentFixture<LeavesettingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LeavesettingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LeavesettingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
