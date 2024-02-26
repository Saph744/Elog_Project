import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddworkingdaysComponent } from './addworkingdays.component';

describe('AddworkingdaysComponent', () => {
  let component: AddworkingdaysComponent;
  let fixture: ComponentFixture<AddworkingdaysComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddworkingdaysComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddworkingdaysComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
