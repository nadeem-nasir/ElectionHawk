import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { INews } from './interfaces';
import { Configuration } from './app.constants';
@Injectable()
export class NewsService
{
    private actionUrl: string;
    constructor(private _http: HttpClient, private _configuration: Configuration)
    {
        this.actionUrl = this._configuration.ServerWithApiUrl + 'news/';
    }
    getNews(pageNumber: number, pageSize: number): Observable<INews[]>
    {
        return this._http.get<INews[]>(this.actionUrl + pageNumber + '/' + pageSize)
            .catch(this.handleError);
    }
    getNewsAll(): Observable<INews[]> {
        return this._http.get<INews[]>(this.actionUrl )
            .catch(this.handleError);
    }
    getNewsById(Id: any): Observable<INews> {
        return this._http.get<INews>(this.actionUrl + Id)
           
            .catch(this.handleError);
    }

    searchNews(newsName:string): Observable<INews[]>
        {
            return this._http.get<INews[]>(this.actionUrl + newsName)
            .catch(this.handleError);
         }

    // Observable or Promise
    public createNews(news: INews): Observable<INews>
    {
        return this._http.post<INews>(this.actionUrl, news)
             .catch(this.handleError);
    }

    public updateNews(news: INews): Observable<INews> {
        return this._http.put<INews>(this.actionUrl, news)
            .catch(this.handleError);;
    }

    public deleteNews(id: any): Observable<INews[]> {
        return this._http.delete(this.actionUrl + id)
            .catch(this.handleError);
    }
   
    private handleError(err: HttpErrorResponse) {
        // in a real world app, we may send the server to some remote logging infrastructure
        // instead of just logging it to the console
        let errorMessage = '';
        if (err.error instanceof Error) {
            // A client-side or network error occurred. Handle it accordingly.
            errorMessage = `An error occurred: ${err.error.message}`;
        } else {
            // The backend returned an unsuccessful response code.
            // The response body may contain clues as to what went wrong,
            errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
        }
        console.error(errorMessage);
        return Observable.throw(errorMessage);
    }
}


