import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PolicysettingComponent } from './policysetting.component';

describe('PolicysettingComponent', () => {
  let component: PolicysettingComponent;
  let fixture: ComponentFixture<PolicysettingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PolicysettingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PolicysettingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
