import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowDeleteHolidayComponent } from './show-delete-holiday.component';

describe('ShowDeleteHolidayComponent', () => {
  let component: ShowDeleteHolidayComponent;
  let fixture: ComponentFixture<ShowDeleteHolidayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowDeleteHolidayComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ShowDeleteHolidayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
