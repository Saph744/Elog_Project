import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditworkingdayComponent } from './editworkingday.component';

describe('EditworkingdayComponent', () => {
  let component: EditworkingdayComponent;
  let fixture: ComponentFixture<EditworkingdayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditworkingdayComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditworkingdayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
