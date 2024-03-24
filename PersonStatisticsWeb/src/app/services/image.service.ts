import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { ImageSearchResponse } from '../interfaces/image-search-response';
import { environment } from 'src/environments/environment.dev';
import { catchError } from 'rxjs/operators';
import { error } from 'console';

@Injectable({
  providedIn: 'root',
})
export class ImageService {
  googleSeachURL = environment.googleSearchUrl;

  constructor(private http: HttpClient) {}

  searchImages(query: string): Observable<ImageSearchResponse> {
    const params = new HttpParams().set('q', query).set('searchType', 'image');

    return this.http
      .get<ImageSearchResponse>(this.googleSeachURL, { params })
      .pipe(
        catchError((err) => {
          console.log('Error in searching for images:', err);
          return throwError(err);
        })
      );
  }
}
