import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { IPollingScheme } from './interfaces';
import { Configuration } from './app.constants';

@Injectable()
export class PollingSchemeService
{
    private actionUrl: string;
    constructor(private _http: HttpClient, private _configuration: Configuration)
    {
        this.actionUrl = this._configuration.ServerWithApiUrl + 'pollingschemestation/';
    }
    getPollingScheme(pageNumber: number, pageSize: number): Observable<IPollingScheme[]>
    {

        return this._http.get<IPollingScheme[]>(this.actionUrl + pageNumber + '/' + pageSize)
            .catch(this.handleError);
    }
getPollingSchemeAll():Observable<IPollingScheme[]>
{
	return this._http.get<IPollingScheme[]>(this.actionUrl).catch(this.handleError);
}

    getPollingSchemeById(Id: any): Observable<IPollingScheme> {

        return this._http.get<IPollingScheme>(this.actionUrl + Id)
           
            .catch(this.handleError);
    }

    searchPollingScheme(pollingSchemeName:string): Observable<IPollingScheme[]>
        {
            return this._http.get<IPollingScheme[]>(this.actionUrl + pollingSchemeName)
            .catch(this.handleError);
         }

    // Observable or Promise
    public createPollingScheme(pollingScheme: IPollingScheme): Observable<IPollingScheme>
    {
        return this._http.post<IPollingScheme>(this.actionUrl, pollingScheme)
             .catch(this.handleError);
    }

    public updatePollingScheme(pollingScheme: IPollingScheme): Observable<IPollingScheme> {
        return this._http.put<IPollingScheme>(this.actionUrl, pollingScheme)
            .catch(this.handleError);;
    }

    public deletePollingScheme(id: any): Observable<IPollingScheme[]> {
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


