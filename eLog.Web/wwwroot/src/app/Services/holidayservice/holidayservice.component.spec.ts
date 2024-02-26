import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HolidayserviceComponent } from './holidayservice.component';

describe('HolidayserviceComponent', () => {
  let component: HolidayserviceComponent;
  let fixture: ComponentFixture<HolidayserviceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HolidayserviceComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HolidayserviceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
