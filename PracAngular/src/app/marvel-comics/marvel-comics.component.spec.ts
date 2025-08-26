import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MarvelComicsComponent } from './marvel-comics.component';

describe('MarvelComicsComponent', () => {
  let component: MarvelComicsComponent;
  let fixture: ComponentFixture<MarvelComicsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MarvelComicsComponent]
    });
    fixture = TestBed.createComponent(MarvelComicsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
