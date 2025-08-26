import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MarvelComic } from './marvel-comic.model';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class MarvelComicsService {
  private apiUrl = 'https://localhost:7041/api/marvelcomics';

  constructor(private http: HttpClient) {}

  getAll(): Observable<MarvelComic[]> {
    return this.http.get<MarvelComic[]>(this.apiUrl);
  }

  add(comic: MarvelComic): Observable<MarvelComic> {
    return this.http.post<MarvelComic>(this.apiUrl, comic);
  }

  update(comic: MarvelComic): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${comic.id}`, comic);
  }

  delete(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
