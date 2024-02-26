import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserleavedetailserviceComponent } from './userleavedetailservice.component';

describe('UserleavedetailserviceComponent', () => {
  let component: UserleavedetailserviceComponent;
  let fixture: ComponentFixture<UserleavedetailserviceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserleavedetailserviceComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UserleavedetailserviceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
