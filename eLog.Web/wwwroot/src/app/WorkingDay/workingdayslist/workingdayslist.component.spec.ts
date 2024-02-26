import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkingdayslistComponent } from './workingdayslist.component';

describe('WorkingdayslistComponent', () => {
  let component: WorkingdayslistComponent;
  let fixture: ComponentFixture<WorkingdayslistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WorkingdayslistComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkingdayslistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
