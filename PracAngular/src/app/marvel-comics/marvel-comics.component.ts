import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MarvelComicsService } from './marvel-comics.service';
import { MarvelComic } from './marvel-comic.model';

@Component({
  selector: 'app-marvel-comics',
  templateUrl: './marvel-comics.component.html'
})
export class MarvelComicsComponent implements OnInit {
  form: FormGroup;
  comics: MarvelComic[] = [];
  isEditing = false;

  constructor(private fb: FormBuilder, private service: MarvelComicsService) {
    this.form = this.fb.group({
      id: [0],
      title: [''],
      hero: [''],
      publisher: [''],
      releaseDate: ['']
    });
  }

  ngOnInit(): void {
    this.loadComics();
  }

  loadComics(): void {
    this.service.getAll().subscribe(data => this.comics = data);
  }

  submit(): void {
    const comic = this.form.value as MarvelComic;

    if (this.isEditing) {
      this.service.update(comic).subscribe(() => {
        this.loadComics();
        this.resetForm();
      });
    } else {
      this.service.add(comic).subscribe(newComic => {
        this.comics.push(newComic);
        this.resetForm();
      });
    }
  }

  edit(comic: MarvelComic): void {
    this.form.setValue(comic);
    this.isEditing = true;
  }

  delete(id: number): void {
    this.service.delete(id).subscribe(() => {
      this.comics = this.comics.filter(c => c.id !== id);
    });
  }

  resetForm(): void {
    this.form.reset({ id: 0, title: '', hero: '', publisher: '', releaseDate: '' });
    this.isEditing = false;
  }
}
